using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.EntityFrameworkCore;
using ZL.Poem.Core;
using ZL.Poem.EF.EntityFramework;

namespace ZL.Poem.EF
{
    [DependsOn(
       typeof(PoemCoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class PoemDataModule : AbpModule
    {
        /* 在单元测试时，使用EF Core的内存数据库，不需要进行数据库注册 */
        public bool SkipDbContextRegistration { get; set; }

        /// <summary>
        /// 初始化时注册DbContext
        /// </summary>
        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<PoemDbContext>(options =>
                {
                    var builder = options.DbContextOptions;
                    if (options.ExistingConnection != null)
                    {
                        builder.UseSqlServer(options.ExistingConnection);
                    }
                    else
                    {
                        builder.UseSqlServer(options.ConnectionString);
                    }
                });
            }
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PoemDataModule).GetAssembly());
        }
    }
}