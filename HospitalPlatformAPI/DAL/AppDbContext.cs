using HospitalPlatformAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalPlatformAPI.DAL;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
     public DbSet<Group> Groups { get; set; }
    // public DbSet<Category> Categories { get; set; }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.ApplyConfiguration(new ProductConfiguration());
    //     modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    //     base.OnModelCreating(modelBuilder);
    // }
}