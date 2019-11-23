using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZL.Poem.Application.Poems;

namespace ZL.Poem.WebApi.Pages
{
    public class IndexModel : PageModel
    {
        private IPoemAppService _appService;
        public List<CategoryDto> Categories;



        /// <summary>
        /// 这里通过依赖注入获取IPoemAppService
        /// </summary>
        /// <param name="appService"></param>
        public IndexModel(IPoemAppService appService)
        {
            _appService = appService;
            
        }

        /// <summary>
        /// 相应Get动作
        /// </summary>
        public void OnGet()
        {
            Categories=_appService.GetAllCategories();
        }
    }
}