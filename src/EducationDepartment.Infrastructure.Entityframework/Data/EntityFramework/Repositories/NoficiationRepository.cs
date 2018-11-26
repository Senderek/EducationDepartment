using AutoMapper;
using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Repositories
{
    public class NoficiationRepository: INoficiationRepository
    {
        private readonly IMapper _mapper;
        public NoficiationRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Notification> GetAllNotifications()
        {
            throw new NotImplementedException();
        }

        public Task SaveNotification()
        {
            throw new NotImplementedException();
        }
    }
}
