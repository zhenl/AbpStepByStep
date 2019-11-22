using Abp.Application.Services.Dto;

namespace ZL.Poem.Application.Poems
{
    /// <summary>
    /// 分页查询传入参数
    /// </summary>
    public class PagedResultRequestDto : IPagedResultRequest
    {
        /// <summary>
        /// 跳过的记录数
        /// </summary>
        public int SkipCount { get; set; }

        /// <summary>
        /// 返回的最大记录数
        /// </summary>
        public int MaxResultCount { get; set; }
    }
}
