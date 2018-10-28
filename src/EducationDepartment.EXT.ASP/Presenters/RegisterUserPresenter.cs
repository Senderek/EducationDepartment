using System.Net;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using EducationDepartment.EXT.ASP.Serialization;

namespace EducationDepartment.EXT.ASP.Presenters
{
    public sealed class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RegisterUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RegisterUserResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
