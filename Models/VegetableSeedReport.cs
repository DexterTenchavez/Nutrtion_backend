using System.ComponentModel.DataAnnotations;

namespace Nutrition_backend.Models
{
    public class VegetableSeedReport
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;
        
        [Required]
        public int Purok { get; set; }
        
        [Required]
        public int TotalHouseholds { get; set; }
        
        public int PoorFamiliesGivenSeeds { get; set; }
        
        public string? SeedType1 { get; set; }
        public int SeedCount1 { get; set; }
        
        public string? SeedType2 { get; set; }
        public int SeedCount2 { get; set; }
        
        public string? SeedType3 { get; set; }
        public int SeedCount3 { get; set; }
        
        public int SubTotal { get; set; }
        
        public int Year { get; set; }
        public DateTime RecordedDate { get; set; } = DateTime.UtcNow;
        
        [MaxLength(100)]
        public string? RecordedBy { get; set; }
    }
}