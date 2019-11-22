using Abp.TestBase;
using System;
using System.Threading.Tasks;
using ZL.Poem.EF.EntityFramework;
using ZL.PoemApplication.Test.TestData;

namespace ZL.PoemApplication.Test
{
    public class PoemTestBase : AbpIntegratedTestBase<PoemApplicationTestModule>
    {
        public PoemTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<PoemDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<PoemDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<PoemDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<PoemDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<PoemDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<PoemDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<PoemDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<PoemDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}

