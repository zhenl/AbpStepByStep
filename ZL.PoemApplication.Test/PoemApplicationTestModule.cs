using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZL.Poem.Application;
using ZL.Poem.EF;
using ZL.Poem.EF.EntityFramework;

namespace ZL.PoemApplication.Test
{
    [DependsOn(
       typeof(PoemApplicationModule),
       typeof(PoemDataModule),
       typeof(AbpTestBaseModule)
       )]
    public class PoemApplicationTestModule : AbpModule
    {

        public PoemApplicationTestModule(PoemDataModule poemDataModule)
        {
            //跳过DbContext注册
            poemDataModule.SkipDbContextRegistration = true;
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
            SetupInMemoryDb();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PoemApplicationTestModule).GetAssembly());
        }

        private void SetupInMemoryDb()
        {
            var services = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(
                IocManager.IocContainer,
                services
            );

            var builder = new DbContextOptionsBuilder<PoemDbContext>();
            builder.UseInMemoryDatabase("mytest").UseInternalServiceProvider(serviceProvider);

            IocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<PoemDbContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );
        }
    }
}

