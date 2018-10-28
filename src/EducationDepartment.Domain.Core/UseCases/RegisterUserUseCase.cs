using System.Linq;
using System.Threading.Tasks;
using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Domain.Core.Interfaces.UseCases;

namespace EducationDepartment.Domain.Core.UseCases
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User(message.FirstName, message.LastName, message.Email, message.UserName), message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
