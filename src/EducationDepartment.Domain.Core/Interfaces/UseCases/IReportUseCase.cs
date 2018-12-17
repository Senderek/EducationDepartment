using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Domain.Core.Interfaces.UseCases
{
    public interface IReportUseCase : IUseCaseRequestHandler<ReportRequest, ReportResponse>
    {

    }
}
