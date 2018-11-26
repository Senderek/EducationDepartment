using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EducationDepartment.Infrastructure.Entityframework.Data.Entities
{
    public class Notification : BaseEntity
    {
        [Required]
        public string Subject { get; set; }
        public string Content { get; set; }
        [Column]
        [Required]
        private String DestinationsAsString { get; set; }
        [NotMapped]
        public List<String> Destinations
        {
            get { return DestinationsAsString.Split(';').ToList(); }
            set
            {
                DestinationsAsString = String.Join(";", value);
            }
        }
    }
}
