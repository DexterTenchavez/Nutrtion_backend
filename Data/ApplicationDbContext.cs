using Microsoft.EntityFrameworkCore;
using Nutrition_backend.Models;

namespace Nutrition_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<VitaminAReport> VitaminAReports { get; set; }
        public DbSet<ChildRecord> ChildRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Unique constraints
    modelBuilder.Entity<User>()
        .HasIndex(u => u.Username)
        .IsUnique();

    modelBuilder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique();

    modelBuilder.Entity<Barangay>()
        .HasIndex(b => b.Name)
        .IsUnique();

    // Remove accidental shadow FK relationship between Barangay and VitaminAReport
    modelBuilder.Entity<Barangay>()
        .Ignore(b => b.Reports);

    // Seed initial data
    modelBuilder.Entity<Barangay>().HasData(
        new Barangay { Id = 1, Name = "Tintinan", IsActive = true },
        new Barangay { Id = 2, Name = "Sample Barangay 1", IsActive = true },
        new Barangay { Id = 3, Name = "Sample Barangay 2", IsActive = true }
    );

    // Seed admin user (password: Admin@123)
    modelBuilder.Entity<User>().HasData(
        new User
        {
            Id = 1,
            Username = "admin",
            Email = "dextertenchavez@gmail.com",
            PasswordHash = "$2a$12$bpNqnsk2pO8EmR7mdumID.oNto8kb6O4xdmyQWf.nZ3ZVZhJnmOmO",
            Role = "admin",
            Barangay = null,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        }
    );
}
    }
}