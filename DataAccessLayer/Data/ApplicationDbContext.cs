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
    public DbSet<ManagerName> ManagerNames { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<BusinessType> BusinessTypes { get; set; }  

    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BusinessType>()
            .HasIndex(b => b.BusinessName);
        
        modelBuilder.Entity<Contact>()
            .HasOne(p => p.ManagerName)
            .WithMany(a => a.Contacts)
            .HasForeignKey(b => b.ManagerNameId);
        
        modelBuilder.Entity<Country>().HasData(
            new Country {CountryID = 1, CountryName = "Vietnam"},
            new Country {CountryID = 2, CountryName = "Singapo"}
            );
        
        modelBuilder.Entity<County>().HasData(
            new County { CountyID = 1, CountryID = 1, CountyName = "Hanoi1" },
            new County { CountyID = 2, CountryID = 2,  CountyName = "Sing1" },
            new County { CountyID = 3, CountryID = 1, CountyName = "Hanoi2"},
            new County { CountyID = 4, CountryID = 2, CountyName = "Sing2"}
        );
    
        modelBuilder.Entity<GovernmentOfficeRegion>().HasData(
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 1, GovernmentOfficeRegionName = "GOV1", Description = "Des1", CountyId = 1, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 2, GovernmentOfficeRegionName = "GOV2", Description = "Des2", CountyId = 2, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 3, GovernmentOfficeRegionName = "AGOV", Description = "Des3", CountyId = 3, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 4, GovernmentOfficeRegionName = "BGOV", Description = "Des4", CountyId = 4, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 5, GovernmentOfficeRegionName = "FGOV", Description = "Des5", CountyId = 3, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 6, GovernmentOfficeRegionName = "MOV", Description = "Des6", CountyId = 4, IsActive = false },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 7, GovernmentOfficeRegionName = "POV", Description = "Des7", CountyId = 2, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 8, GovernmentOfficeRegionName = "TGOV", Description = "Des8", CountyId = 1, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 9, GovernmentOfficeRegionName = "XGOV", Description = "Des9", CountyId = 3, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 10, GovernmentOfficeRegionName = "ZGOV", Description = "Des10", CountyId = 4, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 11, GovernmentOfficeRegionName = "WGOV", Description = "Des11", CountyId = 4, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 12, GovernmentOfficeRegionName = "OGOV", Description = "Des12", CountyId = 2, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 13, GovernmentOfficeRegionName = "RGOV", Description = "Des13", CountyId = 3, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 14, GovernmentOfficeRegionName = "CGOV", Description = "Des14", CountyId = 1, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 15, GovernmentOfficeRegionName = "KGOV", Description = "Des15", CountyId = 2, IsActive = false },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 16, GovernmentOfficeRegionName = "GOV", Description = "Des16", CountyId = 1, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 17, GovernmentOfficeRegionName = "IGOV", Description = "Des17", CountyId = 2, IsActive = false },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 18, GovernmentOfficeRegionName = "JGOV", Description = "Des18", CountyId = 3, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 19, GovernmentOfficeRegionName = "LGOV", Description = "Des19", CountyId = 2, IsActive = false },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 20, GovernmentOfficeRegionName = "HGOV", Description = "Des20", CountyId = 4, IsActive = true },
            new GovernmentOfficeRegion { GovernmentOfficeRegionId = 21, GovernmentOfficeRegionName = "0OV2", Description = "Des21", CountyId = 2, IsActive = true }
        );
    }
}