using EducationDepartment.Domain.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EducationDepartment.Domain.Core.Interfaces.Services
{
    public interface IExcelReportSrv
    {
        void CreateReport(Stream stream, List<ReportingArticle> articles);

    }
}
