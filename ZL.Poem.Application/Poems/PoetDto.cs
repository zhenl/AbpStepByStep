using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.Application.Poems
{
    [AutoMapFrom(typeof(Poet))]
    public class PoetDto : EntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}