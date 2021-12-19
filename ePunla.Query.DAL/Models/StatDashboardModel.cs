using System;
using System.Collections.Generic;

namespace ePunla.Query.DAL.Models
{
    public class StatDashboardModel
    {
        public IEnumerable<StatCropPerBarangayModel> StatCropPerBarangayModel { get; set; }
        public IEnumerable<StatCropStatusPerBarangayModel> StatCropStatusPerBarangayModel { get; set; }
        public IEnumerable<StatFarmerPerBarangayModel> StatFarmerPerBarangayModel { get; set; }
        public StatCountModel StatCountModel { get; set; }
    }
}
