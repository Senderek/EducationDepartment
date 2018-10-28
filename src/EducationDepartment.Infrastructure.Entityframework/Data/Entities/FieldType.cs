using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Infrastructure.Entityframework.Data.Entities
{
    public class FieldType: BaseEntity
    {
        public string Name { get; set; }
        public string Options { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ArticleTypeFieldType> FieldTypeArticleType { get; set; }
    }
}
