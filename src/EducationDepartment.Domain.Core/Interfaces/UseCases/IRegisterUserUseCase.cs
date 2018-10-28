using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;

namespace EducationDepartment.Domain.Core.Interfaces.UseCases
{
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
    }
}
