using Abp.Modules;
using System.Reflection;
using ZL.Poem.Application;
using ZL.Poem.EF;

namespace ZL.Poem.ConsoleClient
{
    [DependsOn(typeof(PoemDataModule),
       typeof(PoemApplicationModule))]
    public class PoemConsoleClientModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Server=localhost; Database=PoemNew; Trusted_Connection=True;";
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}