
namespace ZL.Poem.Application.Poems
{
    public class SearchPoemDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

        public string AuthorName { get; set; }

        public string[] Categories { get; set; }
    }
}
