using ePunla.Query.Domain.Enums;

namespace ePunla.Query.Domain.Dtos
{
    public class PageRequestDto <T>
    {
        public T SearchField { get; set; }
        public PageRequest Page { get; set; }
    }
}
