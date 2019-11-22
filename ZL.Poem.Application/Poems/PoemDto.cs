using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace ZL.Poem.Application.Poems
{
    [AutoMapFrom(typeof(Core.Poems.Poem))]
    public class PoemDto : EntityDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int PoetID { get; set; }

        public string AuthorName { get; set; }

        public string Comments { get; set; }

        public string Volumn { get; set; }

        public string Num { get; set; }
    }
}
