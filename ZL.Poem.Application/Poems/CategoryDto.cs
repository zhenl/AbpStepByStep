using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.Application.Poems
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryDto : EntityDto
    {
        public string CategoryName { get; set; }
    }
}
