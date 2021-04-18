using ePunla.Common.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ePunla.Common.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<FarmCrop> FarmCrops { get; set; }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimCause> ClaimCauses { get; set; }

        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<BarangayArea> BarangayAreas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Crop> Crops { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
