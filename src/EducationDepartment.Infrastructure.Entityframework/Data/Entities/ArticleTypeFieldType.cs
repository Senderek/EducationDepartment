using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Infrastructure.Entityframework.Data.Entities
{
    public class ArticleTypeFieldType
    {
        public int  Id { get; set; }
        public int DefaultPriority { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int FieldTypeId { get; set; }
        public FieldType FieldType { get; set; }
    }
}
