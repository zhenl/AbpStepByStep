using Abp.AutoMapper;
using Abp.Modules;
using System.Reflection;
using ZL.Poem.Application.Poems;
using ZL.Poem.Core;

namespace ZL.Poem.Application
{
    [DependsOn(typeof(PoemCoreModule), typeof(AbpAutoMapperModule))]
    public class PoemApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
        //这里加载Dto到实体的映射规则
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<Core.Poems.Poem, PoemDto>()
                      .ForMember(u => u.AuthorName, options => options.MapFrom(o => o.Author.Name));
            });
        }
    }
}