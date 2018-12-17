using EducationDepartment.Domain.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Domain.Core.Interfaces.Services
{
    public interface IReportFileFactory
    {
        void CreateReport(Stream stream, List<ReportingArticle> articles);
    }
}
