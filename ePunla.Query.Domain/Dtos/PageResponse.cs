namespace ePunla.Query.Domain.Dtos
{
    public class PageResponse
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
