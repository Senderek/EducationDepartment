using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Domain.Core.Domain.Entities
{
    public class ReportingArticle
    {
        public string Author { get; }
        public DateTime Date { get; }
        internal ReportingArticle(string _author, DateTime _date)
        {
            Author = _author;
            Date = _date;
        }
    }
}
