using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Infrastructure.Entityframework.Data.Entities;
using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EducationDepartment.EXT.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IRepository<Article> articleRepository;
        private readonly IRepository<FieldType> fieldTypeRepo;
        private readonly IRepository<ArticleType> articleTypeRepo;
        private readonly IReportingArticlesRepository d;


        public ArticleController(IRepository<Article> _articleRepository, IRepository<FieldType> _fieldTypeRepo, IRepository<ArticleType> _articleTypeRepo, IReportingArticlesRepository _d)
        {
            articleRepository = _articleRepository;
            fieldTypeRepo = _fieldTypeRepo;
            articleTypeRepo = _articleTypeRepo;
            d = _d;
        }

        [HttpPost]
        public async Task<ActionResult> Put([FromBody] Article request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            if (request.Id > 0)
            {
                articleRepository.Update(request);
            }
            else
            {
                articleRepository.Insert(request);
            }
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            return Ok(articleRepository.Get(id));
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            return Ok(articleRepository.GetAll());
        }

        [HttpPost("type")]
        public async Task<ActionResult> CreateFieldType(FieldType type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            fieldTypeRepo.Insert(type);
            return Ok();

        }

        //[HttpPost("articleType")]
        //public async Task<IActionResult> CreateArticleType(ArticleType type)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    await articleTypeRepo.InsertAsync(type);
        //    return Ok(type);
        //}

        [HttpGet("articleType/list")]
        public async Task<IActionResult> GetAllArticleTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            articleTypeRepo.GetAll();
            return Ok();
        }

        [HttpGet("type/list")]
        public IActionResult GetAllFieldTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(fieldTypeRepo.GetAll());
        }

        [HttpPost]
        [Route("fieldType")]
        public async Task<IActionResult> PostFieldType(int? id, string name, string options)
        {
            var at = new FieldType { Name = name, Options = options };
            if (id != null)
            {
                at.Id = (int)id;
                await fieldTypeRepo.UpdateAsync(at);
            }
            else
            {
                await fieldTypeRepo.InsertAsync(at);
            }
            return Ok();
        }

        [HttpPost]
        [Route("articleType")]
        public async Task<IActionResult> PostArticleType(int? id, string name, List<int> fieldTypesIds)
        {
            var at = new ArticleType { Name = name };
            int resultId = 0;
            if (id != null)
            {
                at.Id = (int)id;
                resultId = (int)id;
                await articleTypeRepo.UpdateAsync(at);
            }
            else
            {
                resultId = await articleTypeRepo.InsertAsync(at);
            }
            if (fieldTypesIds.Count > 0 && resultId > 0)
            {
                await d.BoundAritcleTypeToFieldTypes(resultId, fieldTypesIds);
            }
            return Ok();
        }

        [Route("seed")]
        [HttpGet]
        public async Task<IActionResult> SeedData()
        {
            await d.SeedData();
            return Ok();
        }

    }
}