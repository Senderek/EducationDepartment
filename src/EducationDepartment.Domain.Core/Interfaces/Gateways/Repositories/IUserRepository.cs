using System.Threading.Tasks;
using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Dto.GatewayResponses.Repositories;

namespace EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
        Task<User> FindByEmail(string email);
        Task<User> CreateUserFromFacebook(Dto.UseCaseRequests.FacebookLoginRequest message, string password);
    }
}
