using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Infrastructure.Entityframework.Data.Entities
{
    public class Article: BaseEntity
    {
        public ICollection<Field> ContentFields { get; set; }
        public string AuthorId { get; set; }
        public AppUser Author { get; set; }
        public string Name { get; set; }
    }
}
