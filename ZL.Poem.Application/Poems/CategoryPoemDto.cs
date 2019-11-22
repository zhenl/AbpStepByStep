using Abp.Application.Services.Dto;
using Abp.AutoMapper;

using ZL.Poem.Core.Poems;

namespace ZL.Poem.Application.Poems
{
    [AutoMapFrom(typeof(CategoryPoem))]
    public class CategoryPoemDto : EntityDto
    {
        public int CategoryId { get; set; }

        public int PoemId { get; set; }
    }
}
