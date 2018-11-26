using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Domain.Core.Interfaces.Services
{
    public interface IMailSender
    {
        Task SendMail(string messageContent, string messageSubject, List<string> destinations);
    }
}
