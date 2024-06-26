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
     public DbSet<Analysis> Analyses { get; set; }
     public DbSet<Test> Tests { get; set; }
     public DbSet<AnalysisResult> AnalysisResults { get; set; }
     public DbSet<AnalysisNameAndResultEntry> AnalysisNameAndResultEntries { get; set; }
     public DbSet<Doctor> Doctors { get; set; }
     public DbSet<Appointment> Appointments { get; set; }
     public DbSet<Office> Offices { get; set; }
     public DbSet<Examination> Examinations { get; set; }
     public DbSet<DoctorImage> DoctorImages { get; set; }
     // public DbSet<Category> Categories { get; set; }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.ApplyConfiguration(new ProductConfiguration());
    //     modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    //     base.OnModelCreating(modelBuilder);
    // }
}