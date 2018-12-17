using Autofac;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Domain.Core.Interfaces.Services;
using EducationDepartment.Infrastructure.Entityframework.Auth;
using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework;
using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Repositories;
using EducationDepartment.Infrastructure.Entityframework.Mailing;
using EducationDepartment.Infrastructure.Entityframework.Reporting;

namespace EducationDepartment.Infrastructure.Entityframework
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NoficiationRepository>().As<INoficiationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ReportingArticlesRepository>().As<IReportingArticlesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
            builder.RegisterType<MailSender>().As<IMailSender>().InstancePerLifetimeScope();
            builder.RegisterType<ExcelReporting>().As<IExcelReportSrv>().InstancePerLifetimeScope();
            builder.RegisterType<WordReporting>().As<IWordReportSrv>().InstancePerLifetimeScope();


        }
    }
}
