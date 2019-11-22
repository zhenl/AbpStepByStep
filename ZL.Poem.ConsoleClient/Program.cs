using Abp;
using Abp.Dependency;
using System;
using ZL.Poem.ConsoleClient;

namespace ZL.Poem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bootstrapper = AbpBootstrapper.Create<PoemConsoleClientModule>())
            {
                //初始化模块
                bootstrapper.Initialize();

                //从容器中获取Service对象，并执行相应的函数
                var service = IocManager.Instance.Resolve<Service>();
                service.Run();

                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
            }
        }
    }
}