using Autofac;
using CMSApi.Abstraction.Services;
using CMSApi.Services;
using CMSCore;
using CMSCore.Abstraction;
using CMSCore.AppStructure.Abstraction;
using CMSCore.FileManagement;
using CMSCore.Providers;
using CMSRepository;
using CMSRepository.Abstractions;
using CMSRepository.Repositories;
using Infrastructure.JWTService;
using Infrastructure.JWTService.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CMSApi
{
    public class CMSDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterCMSCoreServices(builder);

            RegisterDataBaseServices(builder);

            RegisterSecurityServices(builder);

            RegisterMiscellaneousServices(builder);
        }

        
        private static void RegisterCMSCoreServices(ContainerBuilder builder)
        {
            builder.RegisterType<CMSBuilder>().As<ICMSBuilder>();
            builder.RegisterType<CMSDirector>().As<ICMSDirector>();

            builder.RegisterType<FileSystem>().As<IFileSystem>();
            builder.Register<AppFileStructureBuilder>(c =>
            {
                var fileSystem = c.Resolve<IFileSystem>();

                return new AppFileStructureBuilder("Default.Structure", fileSystem);

            }).As<IFileStructureBuilder>();

            builder.RegisterType<CMSHostRepository>().As<IHostStorage>();

            builder.RegisterType<HostFileStructureGenerator>().As<IHostGenerator>();
            builder.RegisterType<HtmlContentProvider>().As<IPageContentProvider>();
            builder.RegisterType<CMSHostRepository>().As<IHostStorage>();

            builder.RegisterType<HostFactory>().As<IHostFactory>();
            builder.RegisterType<PageFactory>().As<IPageFactory>();

            
        }

        private static void RegisterMiscellaneousServices(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<CMSService>().As<ICMSService>().InstancePerLifetimeScope();
        }

        private static void RegisterSecurityServices(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(PasswordHasher<>)).As(typeof(IPasswordHasher<>)).InstancePerLifetimeScope();
            builder.RegisterType<SymmetricJWTTokenService>().As<IJWTTokenService>().InstancePerLifetimeScope();
        }

        private static void RegisterDataBaseServices(ContainerBuilder builder)
        {
            builder.RegisterType<CMSDBContext>().As<DbContext>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<HostRepository>().As<IHostRepository>().InstancePerLifetimeScope();
        }
    }
}
