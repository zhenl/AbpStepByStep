using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZL.Poem.Application.Poems;

namespace ZL.Poem.WebApi.Pages
{
    public class SearchPoemModel : PageModel
    {
        private IPoemAppService _appService;
        public PagedResultDto<PoemDto> poemResults { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentAuthor { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        /// <summary>
        /// 这里通过依赖注入获取IPoemAppService
        /// </summary>
        /// <param name="appService"></param>
        public SearchPoemModel(IPoemAppService appService)
        {
            _appService = appService;
            PageSize = 20;
            CurrentPage = 0;
            CurrentFilter = "";
        }


        public void OnGet(string SearchString,string author, int? pageIndex)
        {
            if (pageIndex.HasValue && pageIndex.Value > 0)
            {
                CurrentPage = pageIndex.Value;
            }
            CurrentFilter = SearchString;
            CurrentAuthor = author;
            var req = new SearchPoemDto();
            req.Keyword = CurrentFilter;
            req.AuthorName = author;
            req.SkipCount = CurrentPage * PageSize;
            req.MaxResultCount = PageSize;
            poemResults = _appService.SearchPoems(req);
        }
    }
}