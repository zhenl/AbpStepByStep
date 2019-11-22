namespace ZL.Poem.Application.Poems
{
    public class SearchPoetDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
