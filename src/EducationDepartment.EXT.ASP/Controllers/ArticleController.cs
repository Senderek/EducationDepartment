using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ArticleController(IRepository<Article> _articleRepository, IRepository<FieldType> _fieldTypeRepo, IRepository<ArticleType> _articleTypeRepo)
        {
            articleRepository = _articleRepository;
            fieldTypeRepo = _fieldTypeRepo;
            articleTypeRepo = _articleTypeRepo;
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

        [HttpPost("articleType")]
        public async Task<IActionResult> CreateArticleType(ArticleType type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await articleTypeRepo.InsertAsync(type);
            return Ok(type);
        }

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
    }
}