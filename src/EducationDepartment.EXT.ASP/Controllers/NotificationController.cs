using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Interfaces.UseCases;
using EducationDepartment.EXT.ASP.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace EducationDepartment.EXT.ASP.Controllers
{
    public class NotificationController : ControllerBase
    {
        private readonly ISendNotificationUseCase _notificationUseCase;

        public NotificationController(ISendNotificationUseCase notificationUseCase)
        {
            _notificationUseCase = notificationUseCase;
        }

        public async Task<IActionResult> SendNotificationToAll(string notificationMessage, string notificationSubject)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest("Bad model");
            }
            await _notificationUseCase.Handle(new SendNotificationRequest(notificationMessage, notificationSubject), null);
            return Ok();
        }

        public async Task<IActionResult> GetAllNotifications()
        {
            return Ok(await _notificationUseCase.GetNotifications());
        }
    }
}