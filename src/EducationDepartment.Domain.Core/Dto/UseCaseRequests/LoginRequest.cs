using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;

namespace EducationDepartment.Domain.Core.Dto.UseCaseRequests
{
  public class LoginRequest : IUseCaseRequest<LoginResponse>
  {
    public string UserName { get; }
    public string Password { get; }

    public LoginRequest(string userName, string password)
    {
      UserName = userName;
      Password = password;
    }
  }
}
