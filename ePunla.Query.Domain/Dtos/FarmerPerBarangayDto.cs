using System;
using System.Collections.Generic;

namespace ePunla.Query.Domain.Dtos
{
    public class FarmerPerBarangayDto
    {
        public int BarangayId { get; set; }
        public string Barangay { get; set; }
        public IEnumerable<FarmerPerBarangay> Farmers { get; set; }
    }

    public class FarmerPerBarangay
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string MobileNumber { get; set; }
        public int FarmerId { get; set; }
    }
}
