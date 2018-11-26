using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Domain.Core.Domain.Entities
{
    public class Notification
    {
        public int? Id { get; }
        public string Content { get; }
        public string Subject { get; }
        public List<string> Destinations { get; }

        internal Notification(string content, string subject, List<string> destinations, int? id = null)
        {
            Id = id;
            Content = content;
            Subject = subject;
            Destinations = destinations;
        }
    }
}
