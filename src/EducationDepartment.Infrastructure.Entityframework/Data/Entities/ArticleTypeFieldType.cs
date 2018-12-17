using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Infrastructure.Entityframework.Data.Entities
{
    public class ArticleTypeFieldType
    {
        public int ArticleTypeId { get; set; }
        public ArticleType ArticleType { get; set; }
        public int FieldTypeId { get; set; }
        public FieldType FieldType { get; set; }
    }
}
