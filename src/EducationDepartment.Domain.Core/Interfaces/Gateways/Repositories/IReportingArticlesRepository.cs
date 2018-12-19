using EducationDepartment.Domain.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories
{
    public interface IReportingArticlesRepository
    {
        Task<List<ReportingArticle>> GetReportingArticles(DateTime from, DateTime to);
        Task SeedData();
        Task BoundAritcleTypeToFieldTypes(int articleTypeId, List<int> fieldTypeIds);

    }
}
