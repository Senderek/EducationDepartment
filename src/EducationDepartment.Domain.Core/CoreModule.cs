using Autofac;
using EducationDepartment.Domain.Core.Interfaces.UseCases;
using EducationDepartment.Domain.Core.UseCases;

namespace EducationDepartment.Domain.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<FacebookLoginUseCase>().As<IFacebookLoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<NotificationsUseCase>().As<ISendNotificationUseCase>().InstancePerLifetimeScope();

        }
    }
}
