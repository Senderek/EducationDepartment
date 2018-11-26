using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Domain.Core.Interfaces.UseCases
{
    public interface ISendNotificationUseCase : IUseCaseRequestHandler<SendNotificationRequest, SendNotificationResponse>
    {
        Task<Notification> GetNotifications();
    }
}
