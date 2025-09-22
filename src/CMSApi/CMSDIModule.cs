using Autofac;
using CMS.Application.Abstraction.Services;
using CMS.Application.Behaviors;
using CMS.Application.Services;
using CMS.Domain.Repository;
using CMS.Persistence.Repositories;
using CMS.WebApi.Authentication;
using CMS.Infrastructure.DotNetCLI;
using CMS.Infrastructure.JWTProviders;
using Microsoft.AspNetCore.Identity;

namespace CMS.WebApi
{
    public class CMSDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterDataBaseServices(builder);

            RegisterSecurityServices(builder);

            RegisterMiscellaneousServices(builder);

            RegisterDotNetCliServices(builder);
        }

        private static void RegisterDotNetCliServices(ContainerBuilder builder)
        {
            builder.RegisterType<DotnetCli>().As<IDotnetCli>();
        }


        private static void RegisterMiscellaneousServices(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<CMSService>().As<ICMSService>().InstancePerLifetimeScope();
            builder.RegisterType<UserProvider>().As<IUserProvider>().InstancePerLifetimeScope();
        }

        private static void RegisterSecurityServices(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(PasswordHasher<>)).As(typeof(IPasswordHasher<>)).InstancePerLifetimeScope();
            builder.RegisterType<SymmetricJWTTokenProvider>().As<IJWTTokenProvider>().InstancePerLifetimeScope();
        }

        private static void RegisterDataBaseServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<HostRepository>().As<IHostRepository>().InstancePerLifetimeScope();
        }
    }
}
