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
    }
}