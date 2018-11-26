using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationDepartment.Domain.Core.Dto.UseCaseRequests
{
    public class SendNotificationRequest : IUseCaseRequest<SendNotificationResponse>
    {
        public string MessageContent { get; }
        public string MessageSubject { get; }

        public SendNotificationRequest(string messageContent, string messageSubject)
        {
            MessageContent = messageContent;
            MessageSubject = messageSubject;
        }
    }
}
