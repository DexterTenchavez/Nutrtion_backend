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
        public DbSet<AnimalRaisingReport> AnimalRaisingReports { get; set; }
        public DbSet<PotableWaterReport> PotableWaterReports { get; set; }
        public DbSet<IodizedSaltReport> IodizedSaltReports { get; set; }
        public DbSet<CRReport> CRReports { get; set; }
        public DbSet<BackyardGardeningReport> BackyardGardeningReports { get; set; }
        public DbSet<PregnantWomenReport> PregnantWomenReports { get; set; }
        public DbSet<VegetableSeedReport> VegetableSeedReports { get; set; }
        public DbSet<AnimalDispersalReport> AnimalDispersalReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Barangay>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Barangay>()
                .Ignore(b => b.Reports);

            modelBuilder.Entity<AnimalRaisingReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Barangay).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Purok).IsRequired();
                entity.Property(e => e.TotalHouseholds).IsRequired();
                entity.Property(e => e.Year).IsRequired();
                entity.HasIndex(e => new { e.Barangay, e.Purok, e.Year }).IsUnique().HasDatabaseName("IX_AnimalRaising_BarangayPurokYear");
            });

            modelBuilder.Entity<PotableWaterReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Barangay).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Purok).IsRequired();
                entity.Property(e => e.TotalHouseholds).IsRequired();
                entity.Property(e => e.Year).IsRequired();
                entity.HasIndex(e => new { e.Barangay, e.Purok, e.Year }).IsUnique().HasDatabaseName("IX_PotableWater_BarangayPurokYear");
            });

            modelBuilder.Entity<IodizedSaltReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Barangay).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Purok).IsRequired();
                entity.Property(e => e.StoreName).HasMaxLength(200);
                entity.Property(e => e.FineSaltOthers).HasMaxLength(100);
                entity.Property(e => e.RockSaltOthers).HasMaxLength(100);
                entity.Property(e => e.OilOthers).HasMaxLength(100);
                entity.Property(e => e.PreparedBy).HasMaxLength(100);
                entity.Property(e => e.NotedBy).HasMaxLength(100);
                entity.Property(e => e.ApprovedBy).HasMaxLength(100);
                entity.HasIndex(e => new { e.Barangay, e.Purok, e.StoreName }).IsUnique().HasDatabaseName("IX_IodizedSalt_BarangayPurokStore");
            });

            modelBuilder.Entity<CRReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Barangay).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Purok).IsRequired();
                entity.Property(e => e.TotalHouseholds).IsRequired();
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.RecordedBy).HasMaxLength(100);
                entity.HasIndex(e => new { e.Barangay, e.Purok, e.Year }).IsUnique().HasDatabaseName("IX_CR_BarangayPurokYear");
            });

            modelBuilder.Entity<BackyardGardeningReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Barangay).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Purok).IsRequired();
                entity.Property(e => e.TotalHouseholds).IsRequired();
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.RecordedBy).HasMaxLength(100);
                entity.HasIndex(e => new { e.Barangay, e.Purok, e.Year }).IsUnique().HasDatabaseName("IX_Gardening_BarangayPurokYear");
            });

            modelBuilder.Entity<PregnantWomenReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Barangay).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Purok).IsRequired();
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.RecordedBy).HasMaxLength(100);
                entity.HasIndex(e => new { e.Barangay, e.Purok, e.Year }).IsUnique().HasDatabaseName("IX_PregnantWomen_BarangayPurokYear");
            });

            modelBuilder.Entity<VegetableSeedReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Barangay).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Purok).IsRequired();
                entity.Property(e => e.TotalHouseholds).IsRequired();
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.SeedType1).HasMaxLength(50);
                entity.Property(e => e.SeedType2).HasMaxLength(50);
                entity.Property(e => e.SeedType3).HasMaxLength(50);
                entity.Property(e => e.RecordedBy).HasMaxLength(100);
                entity.HasIndex(e => new { e.Barangay, e.Purok, e.Year }).IsUnique().HasDatabaseName("IX_VegetableSeed_BarangayPurokYear");
            });

            modelBuilder.Entity<AnimalDispersalReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Barangay).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Purok).IsRequired();
                entity.Property(e => e.TotalHouseholds).IsRequired();
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.RecordedBy).HasMaxLength(100);
                entity.HasIndex(e => new { e.Barangay, e.Purok, e.Year }).IsUnique().HasDatabaseName("IX_AnimalDispersal_BarangayPurokYear");
            });

            modelBuilder.Entity<Barangay>().HasData(
                new Barangay { Id = 1, Name = "Tintinan", IsActive = true },
                new Barangay { Id = 2, Name = "Sample Barangay 1", IsActive = true },
                new Barangay { Id = 3, Name = "Sample Barangay 2", IsActive = true }
            );

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