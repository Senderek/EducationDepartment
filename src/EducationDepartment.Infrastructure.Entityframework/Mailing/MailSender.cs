using EducationDepartment.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Infrastructure.Entityframework.Mailing
{
    public class MailSender : IMailSender
    {
        public const string senderAdress = "edudepms@gmail.com";
        public const string senderPassword = "P@$$w0rd123";


        public async Task SendMail(string messageContent, string messageSubject, List<string> destinations)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com", // set your SMTP server name here
                Port = 587, // Port 
                EnableSsl = true,
                Credentials = new NetworkCredential(senderAdress, senderPassword)
            };

            using (var message = new MailMessage()
            {
                From = new MailAddress(senderAdress),
                Subject = messageContent,
                Body = messageContent
            })
            {
                foreach(var destination in destinations)
                {
                    message.To.Add(destination);

                }
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
