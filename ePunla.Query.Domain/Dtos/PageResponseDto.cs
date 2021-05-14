using System.Collections.Generic;

namespace ePunla.Query.Domain.Dtos
{
    public class PageResponseDto <T>
    {
        public IEnumerable<T> Values { get; set; }
        public PageResponse Page { get; set; }
    }
}
