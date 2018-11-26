using AutoMapper;
using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EducationDepartment.Infrastructure.Entityframework.Data.Entities;

namespace EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Repositories
{
    public class NoficiationRepository : INoficiationRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public NoficiationRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<NotificationM>> GetAllNotifications()
        {
            var entities = await _dbContext.Notifications.ToListAsync();
            return _mapper.Map<List<NotificationM>>(entities);
        }

        public async Task SaveNotification(NotificationM notification)
        {
            var newObj = _mapper.Map<Notification>(notification);
            await _dbContext.Notifications.AddAsync(newObj);
            await _dbContext.SaveChangesAsync();
        }
    }
}
