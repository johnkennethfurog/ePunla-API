using System;
using System.Collections.Generic;

namespace ePunla.Query.Domain.Dtos
{
    public class FarmerDashboardDto
    {
        public IEnumerable<FarmerDashboardCropStatDto> Planted { get; set; }
        public IEnumerable<FarmerDashboardCropStatDto> Damaged { get; set; }
        public IEnumerable<FarmerDashboardCropStatDto> Harvested { get; set; }
    }
}
