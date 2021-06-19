using ePunla.Query.Domain.Enums;

namespace ePunla.Query.Domain.Dtos
{
    public class SearchAdminClaimFieldsDto
    {
        public ClaimStatus? Status { get; set; }
        public string SearchText { get; set; }
        public int? BarangayId { get; set; }
    }
}
