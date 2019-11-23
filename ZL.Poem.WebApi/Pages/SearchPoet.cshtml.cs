using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZL.Poem.Application.Poems;

namespace ZL.Poem.WebApi.Pages
{
    /// <summary>
    /// 诗人查询的后台代码
    /// </summary>
    public class SearchPoetModel : PageModel
    {
        /// <summary>
        /// 服务
        /// </summary>
        private IPoemAppService _appService;

        /// <summary>
        /// 查询结果
        /// </summary>
        public PagedResultDto<PoetDto> poetResults { get; set; }

        /// <summary>
        /// 当前的查询关键字
        /// </summary>
        public string CurrentFilter { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页面
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 这里通过依赖注入获取IPoemAppService
        /// </summary>
        /// <param name="appService"></param>
        public SearchPoetModel(IPoemAppService appService)
        {
            _appService = appService;
            PageSize = 20;
            CurrentPage = 0;
            CurrentFilter = "";
        }

        /// <summary>
        /// 响应Http Get
        /// </summary>
        /// <param name="SearchString">
        /// 查询的关键字
        /// </param>
        /// <param name="pageIndex">
        /// 页面Index
        /// </param>
        public void OnGet(string SearchString,int? pageIndex)
        {
            if (pageIndex.HasValue && pageIndex.Value>0)
            {
                CurrentPage = pageIndex.Value;
            }
            CurrentFilter = SearchString;
            var req = new SearchPoetDto
            {
                Keyword = CurrentFilter,
                SkipCount = CurrentPage * PageSize,
                MaxResultCount = PageSize
            };
            poetResults = _appService.SearchPoets(req);
        }
    }
}