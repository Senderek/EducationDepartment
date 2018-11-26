using AutoMapper;
using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Infrastructure.Entityframework.Data.Entities;


namespace EducationDepartment.Infrastructure.Entityframework.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, UserName = u.UserName, PasswordHash = u.PasswordHash });
            CreateMap<AppUser, User>().ConstructUsing(au => new User(au.FirstName, au.LastName, au.Email, au.UserName, au.Id, au.PasswordHash));
            //CreateMap<Entities.Notification, Domain.Core.Domain.Entities.Notification>().ConstructUsing(x => new Domain.Core.Domain.Entities.Notification(x.Content, x.Subject, x.Destinations, x.Id));
            //CreateMap<Domain.Core.Domain.Entities.Notification, Entities.Notification>().ConstructUsing(x => new Entities.Notification { Content = x.Content, Destinations = x.Destinations, Subject = x.Subject });
        }
    }
}
