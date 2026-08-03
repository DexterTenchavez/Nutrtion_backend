using Microsoft.EntityFrameworkCore;
using Nutrition_backend.Data;
using Nutrition_backend.DTOs;
using Nutrition_backend.Models;

namespace Nutrition_backend.Services
{
    public interface IReportDataEntryService
    {
        Task<AnimalRaisingResponseDto> CreateAnimalRaisingAsync(AnimalRaisingEntryDto dto);
        Task<List<AnimalRaisingResponseDto>> GetAnimalRaisingAsync(string barangay, int year);
        Task<PotableWaterResponseDto> CreatePotableWaterAsync(PotableWaterEntryDto dto);
        Task<List<PotableWaterResponseDto>> GetPotableWaterAsync(string barangay, int year);
        Task<IodizedSaltResponseDto> CreateIodizedSaltAsync(IodizedSaltEntryDto dto);
        Task<List<IodizedSaltResponseDto>> GetIodizedSaltAsync(string barangay);
        Task<CRResponseDto> CreateCRAsync(CREntryDto dto);
        Task<List<CRResponseDto>> GetCRAsync(string barangay, int year);
        Task<BackyardGardeningResponseDto> CreateBackyardGardeningAsync(BackyardGardeningEntryDto dto);
        Task<List<BackyardGardeningResponseDto>> GetBackyardGardeningAsync(string barangay, int year);
        Task<PregnantWomenResponseDto> CreatePregnantWomenAsync(PregnantWomenEntryDto dto);
        Task<List<PregnantWomenResponseDto>> GetPregnantWomenAsync(string barangay, int year);
        Task<VegetableSeedResponseDto> CreateVegetableSeedAsync(VegetableSeedEntryDto dto);
        Task<List<VegetableSeedResponseDto>> GetVegetableSeedAsync(string barangay, int year);
        Task<AnimalDispersalResponseDto> CreateAnimalDispersalAsync(AnimalDispersalEntryDto dto);
        Task<List<AnimalDispersalResponseDto>> GetAnimalDispersalAsync(string barangay, int year);
    }

    public class ReportDataEntryService : IReportDataEntryService
    {
        private readonly ApplicationDbContext _context;

        public ReportDataEntryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalRaisingResponseDto> CreateAnimalRaisingAsync(AnimalRaisingEntryDto dto)
        {
            var report = new AnimalRaisingReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                TotalHouseholds = dto.TotalHouseholds,
                ChickenMale = dto.ChickenMale,
                ChickenFemale = dto.ChickenFemale,
                PigMale = dto.PigMale,
                PigFemale = dto.PigFemale,
                GoatMale = dto.GoatMale,
                GoatFemale = dto.GoatFemale,
                CowMale = dto.CowMale,
                CowFemale = dto.CowFemale,
                CarabaoMale = dto.CarabaoMale,
                CarabaoFemale = dto.CarabaoFemale,
                Signature = dto.Signature,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = DateTime.UtcNow
            };

            _context.AnimalRaisingReports.Add(report);
            await _context.SaveChangesAsync();

            return new AnimalRaisingResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                TotalHouseholds = report.TotalHouseholds,
                ChickenMale = report.ChickenMale,
                ChickenFemale = report.ChickenFemale,
                PigMale = report.PigMale,
                PigFemale = report.PigFemale,
                GoatMale = report.GoatMale,
                GoatFemale = report.GoatFemale,
                CowMale = report.CowMale,
                CowFemale = report.CowFemale,
                CarabaoMale = report.CarabaoMale,
                CarabaoFemale = report.CarabaoFemale,
                Signature = report.Signature,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<AnimalRaisingResponseDto>> GetAnimalRaisingAsync(string barangay, int year)
        {
            var reports = await _context.AnimalRaisingReports
                .Where(r => r.Barangay == barangay && r.Year == year)
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new AnimalRaisingResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                TotalHouseholds = r.TotalHouseholds,
                ChickenMale = r.ChickenMale,
                ChickenFemale = r.ChickenFemale,
                PigMale = r.PigMale,
                PigFemale = r.PigFemale,
                GoatMale = r.GoatMale,
                GoatFemale = r.GoatFemale,
                CowMale = r.CowMale,
                CowFemale = r.CowFemale,
                CarabaoMale = r.CarabaoMale,
                CarabaoFemale = r.CarabaoFemale,
                Signature = r.Signature,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<PotableWaterResponseDto> CreatePotableWaterAsync(PotableWaterEntryDto dto)
        {
            var report = new PotableWaterReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                TotalHouseholds = dto.TotalHouseholds,
                Level1 = dto.Level1,
                Level2 = dto.Level2,
                Level3 = dto.Level3,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = DateTime.UtcNow
            };

            _context.PotableWaterReports.Add(report);
            await _context.SaveChangesAsync();

            return new PotableWaterResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                TotalHouseholds = report.TotalHouseholds,
                Level1 = report.Level1,
                Level2 = report.Level2,
                Level3 = report.Level3,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<PotableWaterResponseDto>> GetPotableWaterAsync(string barangay, int year)
        {
            var reports = await _context.PotableWaterReports
                .Where(r => r.Barangay == barangay && r.Year == year)
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new PotableWaterResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                TotalHouseholds = r.TotalHouseholds,
                Level1 = r.Level1,
                Level2 = r.Level2,
                Level3 = r.Level3,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<IodizedSaltResponseDto> CreateIodizedSaltAsync(IodizedSaltEntryDto dto)
        {
            var report = new IodizedSaltReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                StoreName = dto.StoreName,
                FineSaltFidel = dto.FineSaltFidel,
                FineSaltUFC = dto.FineSaltUFC,
                FineSaltPacificBay = dto.FineSaltPacificBay,
                FineSaltOthers = dto.FineSaltOthers,
                RockSaltAtlantic = dto.RockSaltAtlantic,
                RockSaltFidel = dto.RockSaltFidel,
                RockSaltLasap = dto.RockSaltLasap,
                RockSaltPagAsa = dto.RockSaltPagAsa,
                RockSaltJay = dto.RockSaltJay,
                RockSaltOthers = dto.RockSaltOthers,
                OilUFC = dto.OilUFC,
                OilJolly = dto.OilJolly,
                OilOthers = dto.OilOthers,
                PreparedBy = dto.PreparedBy,
                NotedBy = dto.NotedBy,
                ApprovedBy = dto.ApprovedBy,
                RecordedDate = DateTime.UtcNow
            };

            _context.IodizedSaltReports.Add(report);
            await _context.SaveChangesAsync();

            return new IodizedSaltResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                StoreName = report.StoreName,
                FineSaltFidel = report.FineSaltFidel,
                FineSaltUFC = report.FineSaltUFC,
                FineSaltPacificBay = report.FineSaltPacificBay,
                FineSaltOthers = report.FineSaltOthers,
                RockSaltAtlantic = report.RockSaltAtlantic,
                RockSaltFidel = report.RockSaltFidel,
                RockSaltLasap = report.RockSaltLasap,
                RockSaltPagAsa = report.RockSaltPagAsa,
                RockSaltJay = report.RockSaltJay,
                RockSaltOthers = report.RockSaltOthers,
                OilUFC = report.OilUFC,
                OilJolly = report.OilJolly,
                OilOthers = report.OilOthers,
                PreparedBy = report.PreparedBy,
                NotedBy = report.NotedBy,
                ApprovedBy = report.ApprovedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<IodizedSaltResponseDto>> GetIodizedSaltAsync(string barangay)
        {
            var reports = await _context.IodizedSaltReports
                .Where(r => r.Barangay == barangay)
                .OrderByDescending(r => r.RecordedDate)
                .ToListAsync();

            return reports.Select(r => new IodizedSaltResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                StoreName = r.StoreName,
                FineSaltFidel = r.FineSaltFidel,
                FineSaltUFC = r.FineSaltUFC,
                FineSaltPacificBay = r.FineSaltPacificBay,
                FineSaltOthers = r.FineSaltOthers,
                RockSaltAtlantic = r.RockSaltAtlantic,
                RockSaltFidel = r.RockSaltFidel,
                RockSaltLasap = r.RockSaltLasap,
                RockSaltPagAsa = r.RockSaltPagAsa,
                RockSaltJay = r.RockSaltJay,
                RockSaltOthers = r.RockSaltOthers,
                OilUFC = r.OilUFC,
                OilJolly = r.OilJolly,
                OilOthers = r.OilOthers,
                PreparedBy = r.PreparedBy,
                NotedBy = r.NotedBy,
                ApprovedBy = r.ApprovedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<CRResponseDto> CreateCRAsync(CREntryDto dto)
        {
            var report = new CRReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                TotalHouseholds = dto.TotalHouseholds,
                WithCR = dto.WithCR,
                WithoutCR = dto.WithoutCR,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = DateTime.UtcNow
            };

            _context.CRReports.Add(report);
            await _context.SaveChangesAsync();

            return new CRResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                TotalHouseholds = report.TotalHouseholds,
                WithCR = report.WithCR,
                WithoutCR = report.WithoutCR,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<CRResponseDto>> GetCRAsync(string barangay, int year)
        {
            var reports = await _context.CRReports
                .Where(r => r.Barangay == barangay && r.Year == year)
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new CRResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                TotalHouseholds = r.TotalHouseholds,
                WithCR = r.WithCR,
                WithoutCR = r.WithoutCR,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<BackyardGardeningResponseDto> CreateBackyardGardeningAsync(BackyardGardeningEntryDto dto)
        {
            var report = new BackyardGardeningReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                TotalHouseholds = dto.TotalHouseholds,
                WithGarden = dto.WithGarden,
                WithoutGarden = dto.WithoutGarden,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = DateTime.UtcNow
            };

            _context.BackyardGardeningReports.Add(report);
            await _context.SaveChangesAsync();

            return new BackyardGardeningResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                TotalHouseholds = report.TotalHouseholds,
                WithGarden = report.WithGarden,
                WithoutGarden = report.WithoutGarden,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<BackyardGardeningResponseDto>> GetBackyardGardeningAsync(string barangay, int year)
        {
            var reports = await _context.BackyardGardeningReports
                .Where(r => r.Barangay == barangay && r.Year == year)
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new BackyardGardeningResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                TotalHouseholds = r.TotalHouseholds,
                WithGarden = r.WithGarden,
                WithoutGarden = r.WithoutGarden,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<PregnantWomenResponseDto> CreatePregnantWomenAsync(PregnantWomenEntryDto dto)
        {
            var report = new PregnantWomenReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                HighBMI = dto.HighBMI,
                LowBMI = dto.LowBMI,
                NormalBMI = dto.NormalBMI,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = DateTime.UtcNow
            };

            _context.PregnantWomenReports.Add(report);
            await _context.SaveChangesAsync();

            return new PregnantWomenResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HighBMI = report.HighBMI,
                LowBMI = report.LowBMI,
                NormalBMI = report.NormalBMI,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<PregnantWomenResponseDto>> GetPregnantWomenAsync(string barangay, int year)
        {
            var reports = await _context.PregnantWomenReports
                .Where(r => r.Barangay == barangay && r.Year == year)
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new PregnantWomenResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                HighBMI = r.HighBMI,
                LowBMI = r.LowBMI,
                NormalBMI = r.NormalBMI,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<VegetableSeedResponseDto> CreateVegetableSeedAsync(VegetableSeedEntryDto dto)
        {
            var report = new VegetableSeedReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                TotalHouseholds = dto.TotalHouseholds,
                PoorFamiliesGivenSeeds = dto.PoorFamiliesGivenSeeds,
                SeedType1 = dto.SeedType1,
                SeedCount1 = dto.SeedCount1,
                SeedType2 = dto.SeedType2,
                SeedCount2 = dto.SeedCount2,
                SeedType3 = dto.SeedType3,
                SeedCount3 = dto.SeedCount3,
                SubTotal = dto.SubTotal,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = DateTime.UtcNow
            };

            _context.VegetableSeedReports.Add(report);
            await _context.SaveChangesAsync();

            return new VegetableSeedResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                TotalHouseholds = report.TotalHouseholds,
                PoorFamiliesGivenSeeds = report.PoorFamiliesGivenSeeds,
                SeedType1 = report.SeedType1,
                SeedCount1 = report.SeedCount1,
                SeedType2 = report.SeedType2,
                SeedCount2 = report.SeedCount2,
                SeedType3 = report.SeedType3,
                SeedCount3 = report.SeedCount3,
                SubTotal = report.SubTotal,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<VegetableSeedResponseDto>> GetVegetableSeedAsync(string barangay, int year)
        {
            var reports = await _context.VegetableSeedReports
                .Where(r => r.Barangay == barangay && r.Year == year)
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new VegetableSeedResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                TotalHouseholds = r.TotalHouseholds,
                PoorFamiliesGivenSeeds = r.PoorFamiliesGivenSeeds,
                SeedType1 = r.SeedType1,
                SeedCount1 = r.SeedCount1,
                SeedType2 = r.SeedType2,
                SeedCount2 = r.SeedCount2,
                SeedType3 = r.SeedType3,
                SeedCount3 = r.SeedCount3,
                SubTotal = r.SubTotal,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<AnimalDispersalResponseDto> CreateAnimalDispersalAsync(AnimalDispersalEntryDto dto)
        {
            var report = new AnimalDispersalReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                TotalHouseholds = dto.TotalHouseholds,
                HouseholdsReceived = dto.HouseholdsReceived,
                ChickenMale = dto.ChickenMale,
                ChickenFemale = dto.ChickenFemale,
                PigMale = dto.PigMale,
                PigFemale = dto.PigFemale,
                GoatMale = dto.GoatMale,
                GoatFemale = dto.GoatFemale,
                CowMale = dto.CowMale,
                CowFemale = dto.CowFemale,
                CarabaoMale = dto.CarabaoMale,
                CarabaoFemale = dto.CarabaoFemale,
                Signature = dto.Signature,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = DateTime.UtcNow
            };

            _context.AnimalDispersalReports.Add(report);
            await _context.SaveChangesAsync();

            return new AnimalDispersalResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                TotalHouseholds = report.TotalHouseholds,
                HouseholdsReceived = report.HouseholdsReceived,
                ChickenMale = report.ChickenMale,
                ChickenFemale = report.ChickenFemale,
                PigMale = report.PigMale,
                PigFemale = report.PigFemale,
                GoatMale = report.GoatMale,
                GoatFemale = report.GoatFemale,
                CowMale = report.CowMale,
                CowFemale = report.CowFemale,
                CarabaoMale = report.CarabaoMale,
                CarabaoFemale = report.CarabaoFemale,
                Signature = report.Signature,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<AnimalDispersalResponseDto>> GetAnimalDispersalAsync(string barangay, int year)
        {
            var reports = await _context.AnimalDispersalReports
                .Where(r => r.Barangay == barangay && r.Year == year)
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new AnimalDispersalResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                TotalHouseholds = r.TotalHouseholds,
                HouseholdsReceived = r.HouseholdsReceived,
                ChickenMale = r.ChickenMale,
                ChickenFemale = r.ChickenFemale,
                PigMale = r.PigMale,
                PigFemale = r.PigFemale,
                GoatMale = r.GoatMale,
                GoatFemale = r.GoatFemale,
                CowMale = r.CowMale,
                CowFemale = r.CowFemale,
                CarabaoMale = r.CarabaoMale,
                CarabaoFemale = r.CarabaoFemale,
                Signature = r.Signature,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }
    }
}