using Abp.Dependency;
using System;
using ZL.Poem.Application.Poems;

namespace ZL.Poem.ConsoleClient
{
    public class Service : ITransientDependency
    {
        private IPoemAppService _appService;


        public Service(IPoemAppService appService)
        {
            _appService = appService;

        }

        public void Run()
        {
            var res = _appService.GetPagedPoets(new PagedResultRequestDto { MaxResultCount = 10, SkipCount = 0 });
            Console.WriteLine(res.TotalCount);
            foreach (var poet in res.Items)
            {
                Console.WriteLine(poet.Name);
            }
        }
    }
}