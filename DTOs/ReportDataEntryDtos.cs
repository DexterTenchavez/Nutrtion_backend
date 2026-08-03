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
        public int TotalHouseholds { get; set; }

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
        public string? Signature { get; set; }
        public int Year { get; set; }
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
        public int TotalHouseholds { get; set; }

        public int Level1 { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
        public int Year { get; set; }
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
        public string? PreparedBy { get; set; }
        public string? NotedBy { get; set; }
        public string? ApprovedBy { get; set; }
    }

    public class CREntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }

        [Required]
        public int TotalHouseholds { get; set; }

        public int WithCR { get; set; }
        public int WithoutCR { get; set; }
        public int Year { get; set; }
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
        public int TotalHouseholds { get; set; }

        public int WithGarden { get; set; }
        public int WithoutGarden { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
    }

    public class PregnantWomenEntryDto
    {
        [Required]
        [MaxLength(100)]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        public int Purok { get; set; }

        public int HighBMI { get; set; }
        public int LowBMI { get; set; }
        public int NormalBMI { get; set; }
        public int Year { get; set; }
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
        public int TotalHouseholds { get; set; }

        public int HouseholdsReceived { get; set; }
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
        public string? Signature { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
    }

    public class AnimalRaisingResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public int TotalHouseholds { get; set; }
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
        public string? Signature { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class PotableWaterResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public int TotalHouseholds { get; set; }
        public int Level1 { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
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
        public string? PreparedBy { get; set; }
        public string? NotedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class CRResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public int TotalHouseholds { get; set; }
        public int WithCR { get; set; }
        public int WithoutCR { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class BackyardGardeningResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public int TotalHouseholds { get; set; }
        public int WithGarden { get; set; }
        public int WithoutGarden { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class PregnantWomenResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public int HighBMI { get; set; }
        public int LowBMI { get; set; }
        public int NormalBMI { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class VegetableSeedResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
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
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }

    public class AnimalDispersalResponseDto
    {
        public int Id { get; set; }
        public string Barangay { get; set; } = string.Empty;
        public int Purok { get; set; }
        public int TotalHouseholds { get; set; }
        public int HouseholdsReceived { get; set; }
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
        public string? Signature { get; set; }
        public int Year { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime RecordedDate { get; set; }
    }
}