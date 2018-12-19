using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Infrastructure.Entityframework.Data.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

        public ReportingArticlesRepository(ApplicationDbContext _context, UserManager<AppUser> userManager)
        {
            context = _context;
            _userManager = userManager;
        }

        public async Task<List<ReportingArticle>> GetReportingArticles(DateTime from, DateTime to)
        {
            var result = new List<ReportingArticle>();
            var reportingAriclesDbo = await context.Articles.Include(x => x.Author).ToListAsync();
            foreach (var article in reportingAriclesDbo)
            {
                var newArticle = new ReportingArticle(article.Author.FirstName + " " + article.Author.LastName, article.Modified, article.Name);
                result.Add(newArticle);
            }
            return result;
        }
        public async Task BoundAritcleTypeToFieldTypes(int articleTypeId, List<int> fieldTypeIds)
        {
            var fieldTypes = await context.FieldTypes.Where(x => fieldTypeIds.Contains(x.Id)).ToListAsync();
            var articleType = await context.ArticleTypes.SingleOrDefaultAsync(x => x.Id == articleTypeId);
            var toAdd = new List<ArticleTypeFieldType>();
            foreach (var id in fieldTypes)
            {
                toAdd.Add(new ArticleTypeFieldType { ArticleType = articleType, FieldType = id });
            }
            await context.AddRangeAsync(toAdd);
            await context.SaveChangesAsync();
        }


        public async Task SeedData()
        {
            var AppUser = new AppUser() { FirstName = "Admin", LastName = "główny", Email = "edudepms@gmail.com", UserName = "Admin1" };
            var AppUser2 = new AppUser() { FirstName = "Jan", LastName = "Kowalski", Email = "edudepms@gmail.com", UserName = "UserJeden" };
            var AppUser3 = new AppUser() { FirstName = "Adam", LastName = "Nowak", Email = "edudepms@gmail.com", UserName = "UserDwa" };

            //var result = await _userManager.CreateAsync(AppUser, "Admin12345");
            var result2 = await _userManager.CreateAsync(AppUser2, "Admin12345");
            var result3 = await _userManager.CreateAsync(AppUser3, "Admin12345");


            var tags = new[]
            {
                new FieldType { Name="plainText",Options="{}" },
            };

            var posts = new[]
            {
                new ArticleType {Name="prostyTekst"  },
            };

            context.AddRange(
                new ArticleTypeFieldType { ArticleType = posts[0], FieldType = tags[0] });
            context.SaveChanges();

            context.AddRange(
                new Article
                {
                    Author = AppUser,
                    Name = "initialArticle",
                    ContentFields = new[]
                {
                    new Field{Content="raz dwa trzy",FieldType= tags[0],Priority=0 }
                }
                },
                new Article
                {
                    Author = AppUser2,
                    Name = "SecondArticle",
                    ContentFields = new[]
                {
                    new Field{Content="super pole",FieldType= tags[0],Priority=0 }
                }
                }, new Article
                {
                    Author = AppUser3,
                    Name = "ThirdArticle",
                    ContentFields = new[]
                {
                    new Field{Content="tekst tekst tekst",FieldType= tags[0],Priority=0 }
                }
                });

            context.SaveChanges();
        }
    }
}
