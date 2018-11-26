using Autofac;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Domain.Core.Interfaces.Services;
using EducationDepartment.Infrastructure.Entityframework.Auth;
using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Repositories;
using EducationDepartment.Infrastructure.Entityframework.Mailing;

namespace EducationDepartment.Infrastructure.Entityframework
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
            builder.RegisterType<MailSender>().As<IMailSender>().InstancePerLifetimeScope();
        }
    }
}
