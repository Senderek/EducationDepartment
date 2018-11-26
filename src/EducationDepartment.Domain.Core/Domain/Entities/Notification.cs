using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Domain.Core.Domain.Entities
{
    public class NotificationM
    {
        public int? Id { get; }
        public string Content { get; }
        public string Subject { get; }
        public List<string> Destinations { get; }

        internal NotificationM(string content, string subject, List<string> destinations = null, int? id = null)
        {
            Id = id;
            Content = content;
            Subject = subject;
            Destinations = destinations;
        }
    }
}
