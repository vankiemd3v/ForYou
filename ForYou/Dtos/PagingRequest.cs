namespace ForYou.Dtos
{
    public class PagingRequest
    {
        public string? Keyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }
}
