using System.Threading.Tasks;
using EducationDepartment.Domain.Core.Dto;

namespace EducationDepartment.Domain.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName);
    }
}
