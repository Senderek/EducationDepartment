using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Domain.Core.Interfaces.UseCases
{
    public interface IFacebookLoginUseCase: IUseCaseRequestHandler<FacebookLoginRequest, LoginResponse>
    {
        bool Fail(string message, IOutputPort<LoginResponse> outputPort);
    }
}
