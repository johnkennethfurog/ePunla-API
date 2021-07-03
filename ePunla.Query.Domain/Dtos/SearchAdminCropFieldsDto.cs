using System;
namespace ePunla.Query.Domain.Dtos
{
    public class SearchAdminCropFieldsDto
    {
        public string SearchText { get; set; }
        public int? CategoryId { get; set; }
        public bool ShowInactive { get; set; }
    }
}
