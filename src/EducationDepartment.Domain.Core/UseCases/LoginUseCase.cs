﻿using System.Threading.Tasks;
using EducationDepartment.Domain.Core.Dto;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Domain.Core.Interfaces.Services;
using EducationDepartment.Domain.Core.Interfaces.UseCases;

namespace EducationDepartment.Domain.Core.UseCases
{
    public sealed class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;

        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.UserName) && !string.IsNullOrEmpty(message.Password))
            {
                // confirm we have a user with the given name
                var user = await _userRepository.FindByName(message.UserName);
                if (user != null)
                {
                    // validate password
                    if (await _userRepository.CheckPassword(user, message.Password))
                    {
                        // generate token
                        outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName),true));
                        return true;
                    }
                }
            }
            outputPort.Handle(new LoginResponse(new[] { new Error("login_failure", "Invalid username or password.") }));
            return false;
        }
    }
}
