using Abp.Modules;
using System.Reflection;

namespace ZL.Poem.Core
{
    public class PoemCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}