using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Infrastructure.Entityframework.Data.Entities
{
    public class Field : BaseEntity
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int FieldTypeId { get; set; }
        public FieldType FieldType { get; set; }
        public string Content { get; set; }
        public int Priority { get; set; }
    }
}
