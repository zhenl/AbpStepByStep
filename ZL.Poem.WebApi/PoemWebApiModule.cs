using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System.Reflection;
using ZL.Poem.Application;
using ZL.Poem.EF;

namespace ZL.Poem.WebApi
{
    [DependsOn(typeof(PoemDataModule),
       typeof(PoemApplicationModule),
        typeof(AbpAspNetCoreModule))]

    public class PoemWebApiModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Server=localhost; Database=PoemNew; Trusted_Connection=True;";
            //创建动态Web Api
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(PoemApplicationModule).Assembly, moduleName: "app", useConventionalHttpVerbs: false);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PoemWebApiModule).GetAssembly());
        }
    }
}

