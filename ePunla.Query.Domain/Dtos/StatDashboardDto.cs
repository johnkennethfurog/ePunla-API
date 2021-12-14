using System;
using System.Collections.Generic;

namespace ePunla.Query.Domain.Dtos
{
    public class StatDashboardDto
    {
        public IEnumerable<StatCropPerBarangayDto> StatCropPerBarangayDto { get; set; }
        public IEnumerable<StatCropStatusPerBarangayDto> StatCropStatusPerBarangayDto { get; set; }
        public IEnumerable<StatFarmerPerBarangayDto> StatFarmerPerBarangayDto { get; set; }
    }
}
