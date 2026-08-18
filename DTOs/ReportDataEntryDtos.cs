using System.ComponentModel.DataAnnotations;

namespace Nutrition_backend.DTOs
{
    public class AnimalRaisingEntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }

        [Required]
        public string HouseholdName { get; set; } = string.Empty;

        public int ChickenMale { get; set; }
        public int ChickenFemale { get; set; }
        public int PigMale { get; set; }
        public int PigFemale { get; set; }
        public int GoatMale { get; set; }
        public int GoatFemale { get; set; }
        public int CowMale { get; set; }
        public int CowFemale { get; set; }
        public int CarabaoMale { get; set; }
        public int CarabaoFemale { get; set; }
        
        public int Year { get; set; }
        public DateTime RecordedDate { get; set; }
        public string? RecordedBy { get; set; }
    }

    public class PotableWaterEntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }

        [Required]
    public string HouseholdName { get; set; } = string.Empty;

        public bool Level1 { get; set; }
        public bool Level2 { get; set; }
        public bool Level3 { get; set; }
        public int Year { get; set; }
        public DateTime RecordedDate { get; set; }
        public string? RecordedBy { get; set; }
    }

    public class IodizedSaltEntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }

        [MaxLength(200)]
        public string? StoreName { get; set; }

        public bool FineSaltFidel { get; set; }
        public bool FineSaltUFC { get; set; }
        public bool FineSaltPacificBay { get; set; }
        public string? FineSaltOthers { get; set; }
        public bool RockSaltAtlantic { get; set; }
        public bool RockSaltFidel { get; set; }
        public bool RockSaltLasap { get; set; }
        public bool RockSaltPagAsa { get; set; }
        public bool RockSaltJay { get; set; }
        public string? RockSaltOthers { get; set; }
        public bool OilUFC { get; set; }
        public bool OilJolly { get; set; }
        public string? OilOthers { get; set; }
         public DateTime RecordedDate { get; set; } // Added
    public string? RecordedBy { get; set; }
    }

    public class CREntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }

         [Required]
        public string HouseholdName { get; set; } = string.Empty;

        public bool WithCR { get; set; } // Changed from int to bool
    public bool WithoutCR { get; set; }
        public int Year { get; set; }
        public DateTime RecordedDate { get; set; }
        public string? RecordedBy { get; set; }
    }

    public class BackyardGardeningEntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }

       [Required]
       public string HouseholdName { get; set; } = string.Empty;

       public bool HasGarden { get; set; }
        public int Year { get; set; }
        public DateTime RecordedDate { get; set; }
        public string? RecordedBy { get; set; }
    }

    public class PregnantWomenEntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }
        [Required]
     public string WomanName { get; set; } = string.Empty;

        public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public decimal BMI { get; set; }
    public string? BMICategory { get; set; }
    public int Year { get; set; }
    public DateTime RecordedDate { get; set; }
        public string? RecordedBy { get; set; }
    }

    public class VegetableSeedEntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }

        [Required]
    public string HouseholdName { get; set; } = string.Empty;

    public string? SeedTypes { get; set; }
        public int Year { get; set; }
        public DateTime RecordedDate { get; set; }
        public string? RecordedBy { get; set; }
    }

    public class AnimalDispersalEntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }

        [Required]
    public string HouseholdName { get; set; } = string.Empty;
        public int ChickenMale { get; set; }
        public int ChickenFemale { get; set; }
        public int PigMale { get; set; }
        public int PigFemale { get; set; }
        public int GoatMale { get; set; }
        public int GoatFemale { get; set; }
        public int CowMale { get; set; }
        public int CowFemale { get; set; }
        public int CarabaoMale { get; set; }
        public int CarabaoFemale { get; set; }
        public DateTime RecordedDate { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
    }

    public class AnimalRaisingResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public string HouseholdName { get; set; } = string.Empty;
        public int ChickenMale { get; set; }
        public int ChickenFemale { get; set; }
        public int PigMale { get; set; }
        public int PigFemale { get; set; }
        public int GoatMale { get; set; }
        public int GoatFemale { get; set; }
        public int CowMale { get; set; }
        public int CowFemale { get; set; }
        public int CarabaoMale { get; set; }
        public int CarabaoFemale { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class PotableWaterResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
         public string HouseholdName { get; set; } = string.Empty;
        public bool Level1 { get; set; }
        public bool Level2 { get; set; }
        public bool Level3 { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class IodizedSaltResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public string? StoreName { get; set; }
        public bool FineSaltFidel { get; set; }
        public bool FineSaltUFC { get; set; }
        public bool FineSaltPacificBay { get; set; }
        public string? FineSaltOthers { get; set; }
        public bool RockSaltAtlantic { get; set; }
        public bool RockSaltFidel { get; set; }
        public bool RockSaltLasap { get; set; }
        public bool RockSaltPagAsa { get; set; }
        public bool RockSaltJay { get; set; }
        public string? RockSaltOthers { get; set; }
        public bool OilUFC { get; set; }
        public bool OilJolly { get; set; }
        public string? OilOthers { get; set; }
        public DateTime RecordedDate { get; set; }
        public string? RecordedBy { get; set; }
        public int Year { get; set; }
    }

    public class CRResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public string HouseholdName { get; set; } = string.Empty;
        public bool WithCR { get; set; }
        public bool WithoutCR { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class BackyardGardeningResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public string HouseholdName { get; set; } = string.Empty;
        public bool HasGarden { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class PregnantWomenResponseDto
{
    public int Id { get; set; }
    public string Barangay { get; set; } = string.Empty;
    public int Purok { get; set; }
    public string WomanName { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public decimal BMI { get; set; }
    public string? BMICategory { get; set; }
    public int Year { get; set; }
    public string? RecordedBy { get; set; }
    public DateTime RecordedDate { get; set; }
}

    public class VegetableSeedResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public string HouseholdName { get; set; } = string.Empty;
    public string? SeedTypes { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class AnimalDispersalResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public string HouseholdName { get; set; } = string.Empty;
        public int ChickenMale { get; set; }
        public int ChickenFemale { get; set; }
        public int PigMale { get; set; }
        public int PigFemale { get; set; }
        public int GoatMale { get; set; }
        public int GoatFemale { get; set; }
        public int CowMale { get; set; }
        public int CowFemale { get; set; }
        public int CarabaoMale { get; set; }
        public int CarabaoFemale { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }
}