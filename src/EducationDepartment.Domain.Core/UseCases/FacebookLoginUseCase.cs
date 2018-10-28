using EducationDepartment.Domain.Core.Dto;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Domain.Core.Interfaces.Services;
using EducationDepartment.Domain.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Domain.Core.UseCases
{
    public sealed class FacebookLoginUseCase : IFacebookLoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;

        public FacebookLoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public bool Fail(string message, IOutputPort<LoginResponse> outputPort)
        {
            outputPort.Handle(new LoginResponse(new[] { new Error("facebook_login_failure", message) }));
            return false;
        }

        public async Task<bool> Handle(FacebookLoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            var user = await _userRepository.FindByEmail(message.Email);
            if (user == null)
            {
                user = await _userRepository.CreateUserFromFacebook(message, Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8));
                if(user == null)
                {
                    outputPort.Handle(new LoginResponse(new[] { new Error("facebook_login_failure", "Failed to create new user.") }));
                    return false;
                }
            }
            outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName), true));
            return true;

        }
    }
}
