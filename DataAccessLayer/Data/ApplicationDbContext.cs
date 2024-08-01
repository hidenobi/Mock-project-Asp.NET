using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Programme> Programmes { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<GovernmentOfficeRegion> GovernmentOfficeRegions { get; set; }
    public DbSet<County> Counties { get; set; }
    public DbSet<TypeOfBusiness> Businesses { get; set; }
    public DbSet<ManagerName> ManagerNames { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<County>().HasData(
            new County { CountyId = 1, CountyName = "Vietnam" },
            new County { CountyId = 2, CountyName = "USA" }
        );
    
        modelBuilder.Entity<GovernmentOfficeRegion>().HasData(
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 1, GovernmentOfficeRegionName = "GOV1", Description = "Des1", CountyId = 1, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 2, GovernmentOfficeRegionName = "GOV2", Description = "Des2", CountyId = 2, IsActive = true }
        );
    }
}