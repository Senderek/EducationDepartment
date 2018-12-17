using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Repositories
{
    public class ReportingArticlesRepository : IReportingArticlesRepository
    {
        private readonly ApplicationDbContext context;

        public ReportingArticlesRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<List<ReportingArticle>> GetReportingArticles(DateTime from, DateTime to)
        {
            var result = new List<ReportingArticle>();
            var reportingAriclesDbo = await context.Articles.Include(x => x.Author).ToListAsync();
            foreach (var article in reportingAriclesDbo)
            {
                var newArticle = new ReportingArticle(article.Author.FirstName + " " + article.Author.LastName, article.Modified);
                result.Add(newArticle);
            }
            return result;
        }
    }
}
