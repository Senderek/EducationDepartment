using EducationDepartment.Domain.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories
{
    public interface INoficiationRepository
    {
        Task SaveNotification(NotificationM notification);
        Task<List<NotificationM>> GetAllNotifications();

    }
}
