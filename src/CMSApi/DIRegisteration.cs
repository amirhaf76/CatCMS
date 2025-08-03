using Autofac;
using CMSApi.Abstraction.Services;
using CMSApi.Services;
using CMSRepository;
using CMSRepository.Abstractions;
using CMSRepository.Repositories;
using Infrastructure.JWTService;
using Infrastructure.JWTService.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CMSApi
{
    public static class DIRegistration
    {
        public static void RegisterCMSServices(this ContainerBuilder builder)
        {
            builder.RegisterType<CMSDBContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(PasswordHasher<>)).As(typeof(IPasswordHasher<>)).InstancePerLifetimeScope();
            builder.RegisterType<SymmetricJWTTokenService>().As<IJWTTokenService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
        }
    }

    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<CMSDBContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(PasswordHasher<>)).As(typeof(IPasswordHasher<>)).InstancePerLifetimeScope();
            builder.RegisterType<SymmetricJWTTokenService>().As<IJWTTokenService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
        }
    }
}
