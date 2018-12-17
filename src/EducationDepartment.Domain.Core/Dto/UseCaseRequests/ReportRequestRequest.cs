using EducationDepartment.Domain.Core.Domain.Enums;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Domain.Core.Dto.UseCaseRequests
{
    public class ReportRequest : IUseCaseRequest<ReportResponse>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public FileType FileType { get; set; }

    }
}
