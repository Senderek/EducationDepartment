using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Infrastructure.Entityframework.Data.Entities
{
    public class ArticleType : BaseEntity
    {
        public ICollection<ArticleTypeFieldType> ArticleTypeFieldTypes { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
