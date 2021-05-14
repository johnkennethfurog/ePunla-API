using System.Collections.Generic;

namespace ePunla.Query.Domain.Dtos
{
    public class PageResponseDto <T>
    {
        public IEnumerable<T> Values { get; set; }
        public Page Page { get; set; }
    }
}
