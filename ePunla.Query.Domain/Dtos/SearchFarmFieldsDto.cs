using System;
using ePunla.Query.Domain.Enums;

namespace ePunla.Query.Domain.Dtos
{
    public class SearchFarmFieldsDto
    {
        public FarmStatus? Status { get; set; }
        public int? BarangayId { get; set; }
        public string SearchText { get; set; }
    }
}
