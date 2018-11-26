using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Dto.UseCaseResponses;
using EducationDepartment.Domain.Core.Interfaces;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Domain.Core.Interfaces.Services;
using EducationDepartment.Domain.Core.Interfaces.UseCases;

namespace EducationDepartment.Domain.Core.UseCases
{
    public class NotificationsUseCase : ISendNotificationUseCase
    {
        private readonly IMailSender _mailSenderSrv;
        private readonly IUserRepository _userRepository;
        private readonly INoficiationRepository _ntfRepository;


        public NotificationsUseCase(IMailSender mailSenderSrv, IUserRepository userRepository, INoficiationRepository ntfRepository)
        {
            _mailSenderSrv = mailSenderSrv;
            _userRepository = userRepository;
            _ntfRepository = ntfRepository;
        }
        public async Task<bool> Handle(SendNotificationRequest message, IOutputPort<SendNotificationResponse> outputPort)
        {
            await _mailSenderSrv.SendMail(message.MessageContent, message.MessageSubject, await _userRepository.GetAllMails());
            return true;
        }
        public async Task<Notification> GetNotifications()
        {
            var result = await _ntfRepository.GetAllNotifications();
            return result;
        }
    }
}
