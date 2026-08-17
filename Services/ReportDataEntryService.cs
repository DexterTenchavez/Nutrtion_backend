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
        Task<AnimalRaisingResponseDto> UpdateAnimalRaisingAsync(int id, AnimalRaisingEntryDto dto);
        Task<bool> DeleteAnimalRaisingAsync(int id);

        Task<PotableWaterResponseDto> CreatePotableWaterAsync(PotableWaterEntryDto dto);
        Task<List<PotableWaterResponseDto>> GetPotableWaterAsync(string barangay, int year);
        Task<PotableWaterResponseDto> UpdatePotableWaterAsync(int id, PotableWaterEntryDto dto);
        Task<bool> DeletePotableWaterAsync(int id);

        Task<IodizedSaltResponseDto> CreateIodizedSaltAsync(IodizedSaltEntryDto dto);
        Task<List<IodizedSaltResponseDto>> GetIodizedSaltAsync(string barangay, int year);
        Task<IodizedSaltResponseDto> UpdateIodizedSaltAsync(int id, IodizedSaltEntryDto dto);
        Task<bool> DeleteIodizedSaltAsync(int id);

        Task<CRResponseDto> CreateCRAsync(CREntryDto dto);
        Task<List<CRResponseDto>> GetCRAsync(string barangay, int year);
        Task<CRResponseDto> UpdateCRAsync(int id, CREntryDto dto);
        Task<bool> DeleteCRAsync(int id);

        Task<BackyardGardeningResponseDto> CreateBackyardGardeningAsync(BackyardGardeningEntryDto dto);
        Task<List<BackyardGardeningResponseDto>> GetBackyardGardeningAsync(string barangay, int year);
        Task<BackyardGardeningResponseDto> UpdateBackyardGardeningAsync(int id, BackyardGardeningEntryDto dto);
        Task<bool> DeleteBackyardGardeningAsync(int id);

        Task<PregnantWomenResponseDto> CreatePregnantWomenAsync(PregnantWomenEntryDto dto);
        Task<List<PregnantWomenResponseDto>> GetPregnantWomenAsync(string barangay, int year);
        Task<PregnantWomenResponseDto> UpdatePregnantWomenAsync(int id, PregnantWomenEntryDto dto);
        Task<bool> DeletePregnantWomenAsync(int id);

        Task<VegetableSeedResponseDto> CreateVegetableSeedAsync(VegetableSeedEntryDto dto);
        Task<List<VegetableSeedResponseDto>> GetVegetableSeedAsync(string barangay, int year);
        Task<VegetableSeedResponseDto> UpdateVegetableSeedAsync(int id, VegetableSeedEntryDto dto);
        Task<bool> DeleteVegetableSeedAsync(int id);

        Task<AnimalDispersalResponseDto> CreateAnimalDispersalAsync(AnimalDispersalEntryDto dto);
        Task<List<AnimalDispersalResponseDto>> GetAnimalDispersalAsync(string barangay, int year);
        Task<AnimalDispersalResponseDto> UpdateAnimalDispersalAsync(int id, AnimalDispersalEntryDto dto);
        Task<bool> DeleteAnimalDispersalAsync(int id);


        Task<bool> CheckAnimalRaisingDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null);
        Task<bool> CheckAnimalDispersalDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null);
        Task<bool> CheckPotableWaterDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null);
        Task<bool> CheckCRDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null);
        Task<bool> CheckBackyardGardeningDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null);
        Task<bool> CheckPregnantWomenDuplicateAsync(string womanName, string barangay, int purok, int? excludeId = null);
        Task<bool> CheckVegetableSeedDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null);
        Task<bool> CheckIodizedSaltDuplicateAsync(string? storeName, string barangay, int purok, int? excludeId = null);
    }

    public class ReportDataEntryService : IReportDataEntryService
    {
        private readonly ApplicationDbContext _context;

        public ReportDataEntryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==================== ANIMAL RAISING ====================
        public async Task<AnimalRaisingResponseDto> CreateAnimalRaisingAsync(AnimalRaisingEntryDto dto)
        {
            var exists = await CheckAnimalRaisingDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            var report = new AnimalRaisingReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                HouseholdName = dto.HouseholdName,
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
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = dto.RecordedDate
            };

            _context.AnimalRaisingReports.Add(report);
            await _context.SaveChangesAsync();

            return new AnimalRaisingResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
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
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<AnimalRaisingResponseDto> UpdateAnimalRaisingAsync(int id, AnimalRaisingEntryDto dto)
        {
            var report = await _context.AnimalRaisingReports.FindAsync(id);
            if (report == null)
                throw new KeyNotFoundException($"Record with ID {id} not found");

            var exists = await CheckAnimalRaisingDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok, id);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            report.Barangay = dto.Barangay;
            report.Purok = dto.Purok;
            report.HouseholdName = dto.HouseholdName;
            report.ChickenMale = dto.ChickenMale;
            report.ChickenFemale = dto.ChickenFemale;
            report.PigMale = dto.PigMale;
            report.PigFemale = dto.PigFemale;
            report.GoatMale = dto.GoatMale;
            report.GoatFemale = dto.GoatFemale;
            report.CowMale = dto.CowMale;
            report.CowFemale = dto.CowFemale;
            report.CarabaoMale = dto.CarabaoMale;
            report.CarabaoFemale = dto.CarabaoFemale;
            report.Year = dto.Year;
            report.RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow;
            report.RecordedBy = dto.RecordedBy;

            await _context.SaveChangesAsync();

            return new AnimalRaisingResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
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
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<AnimalRaisingResponseDto>> GetAnimalRaisingAsync(string barangay, int year)
        {
            var query = _context.AnimalRaisingReports.AsQueryable();

            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            if (year != 0)
            {
                query = query.Where(r => r.Year == year);
            }

            var reports = await query
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new AnimalRaisingResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                HouseholdName = r.HouseholdName,
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
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<bool> DeleteAnimalRaisingAsync(int id)
        {
            var report = await _context.AnimalRaisingReports.FindAsync(id);
            if (report == null) return false;
            _context.AnimalRaisingReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        // ==================== POTABLE WATER ====================
        public async Task<PotableWaterResponseDto> CreatePotableWaterAsync(PotableWaterEntryDto dto)
        {
            var exists = await CheckPotableWaterDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            var report = new PotableWaterReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                HouseholdName = dto.HouseholdName,
                Level1 = dto.Level1,
                Level2 = dto.Level2,
                Level3 = dto.Level3,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow
            };

            _context.PotableWaterReports.Add(report);
            await _context.SaveChangesAsync();

            return new PotableWaterResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
                Level1 = report.Level1,
                Level2 = report.Level2,
                Level3 = report.Level3,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<PotableWaterResponseDto> UpdatePotableWaterAsync(int id, PotableWaterEntryDto dto)
        {
            var report = await _context.PotableWaterReports.FindAsync(id);
            if (report == null)
                throw new KeyNotFoundException($"Record with ID {id} not found");

            var exists = await CheckPotableWaterDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok, id);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            report.Barangay = dto.Barangay;
            report.Purok = dto.Purok;
            report.HouseholdName = dto.HouseholdName;
            report.Level1 = dto.Level1;
            report.Level2 = dto.Level2;
            report.Level3 = dto.Level3;
            report.Year = dto.Year;
            report.RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow;
            report.RecordedBy = dto.RecordedBy;

            await _context.SaveChangesAsync();

            return new PotableWaterResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
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
            var query = _context.PotableWaterReports.AsQueryable();

            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            if (year != 0)
            {
                query = query.Where(r => r.Year == year);
            }

            var reports = await query
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new PotableWaterResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                HouseholdName = r.HouseholdName,
                Level1 = r.Level1,
                Level2 = r.Level2,
                Level3 = r.Level3,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<bool> DeletePotableWaterAsync(int id)
        {
            var report = await _context.PotableWaterReports.FindAsync(id);
            if (report == null) return false;
            _context.PotableWaterReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        // ==================== IODIZED SALT ====================
        public async Task<IodizedSaltResponseDto> CreateIodizedSaltAsync(IodizedSaltEntryDto dto)
        {
            var exists = await CheckIodizedSaltDuplicateAsync(dto.StoreName, dto.Barangay, dto.Purok);
            if (exists)
            {
                throw new InvalidOperationException($"A store named '{dto.StoreName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

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
                RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow,
                Year = dto.RecordedDate.Year
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
                RecordedDate = report.RecordedDate,
                Year = report.Year
            };
        }

        public async Task<IodizedSaltResponseDto> UpdateIodizedSaltAsync(int id, IodizedSaltEntryDto dto)
        {
            var report = await _context.IodizedSaltReports.FindAsync(id);
            if (report == null)
                throw new KeyNotFoundException($"Record with ID {id} not found");

            var exists = await CheckIodizedSaltDuplicateAsync(dto.StoreName, dto.Barangay, dto.Purok, id);
            if (exists)
            {
                throw new InvalidOperationException($"A store named '{dto.StoreName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            report.Barangay = dto.Barangay;
            report.Purok = dto.Purok;
            report.StoreName = dto.StoreName;
            report.FineSaltFidel = dto.FineSaltFidel;
            report.FineSaltUFC = dto.FineSaltUFC;
            report.FineSaltPacificBay = dto.FineSaltPacificBay;
            report.FineSaltOthers = dto.FineSaltOthers;
            report.RockSaltAtlantic = dto.RockSaltAtlantic;
            report.RockSaltFidel = dto.RockSaltFidel;
            report.RockSaltLasap = dto.RockSaltLasap;
            report.RockSaltPagAsa = dto.RockSaltPagAsa;
            report.RockSaltJay = dto.RockSaltJay;
            report.RockSaltOthers = dto.RockSaltOthers;
            report.OilUFC = dto.OilUFC;
            report.OilJolly = dto.OilJolly;
            report.OilOthers = dto.OilOthers;
            report.RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow;
            report.RecordedBy = dto.RecordedBy;
            report.Year = report.RecordedDate.Year;

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
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<IodizedSaltResponseDto>> GetIodizedSaltAsync(string barangay, int year)
        {
            var query = _context.IodizedSaltReports.AsQueryable();

            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            if (year != 0)
            {
                query = query.Where(r => r.Year == year);
            }

            var reports = await query
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
                RecordedDate = r.RecordedDate,
                RecordedBy = r.RecordedBy,
                Year = r.Year
            }).ToList();
        }

        public async Task<bool> DeleteIodizedSaltAsync(int id)
        {
            var report = await _context.IodizedSaltReports.FindAsync(id);
            if (report == null) return false;
            _context.IodizedSaltReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        // ==================== CR ====================
        public async Task<CRResponseDto> CreateCRAsync(CREntryDto dto)
        {
            var exists = await CheckCRDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            var report = new CRReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                HouseholdName = dto.HouseholdName,
                WithCR = dto.WithCR,
                WithoutCR = dto.WithoutCR,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow
            };

            _context.CRReports.Add(report);
            await _context.SaveChangesAsync();

            return new CRResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
                WithCR = report.WithCR,
                WithoutCR = report.WithoutCR,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<CRResponseDto> UpdateCRAsync(int id, CREntryDto dto)
        {
            var report = await _context.CRReports.FindAsync(id);
            if (report == null)
                throw new KeyNotFoundException($"Record with ID {id} not found");

            var exists = await CheckCRDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok, id);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            report.Barangay = dto.Barangay;
            report.Purok = dto.Purok;
            report.HouseholdName = dto.HouseholdName;
            report.WithCR = dto.WithCR;
            report.WithoutCR = dto.WithoutCR;
            report.Year = dto.Year;
            report.RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow;
            report.RecordedBy = dto.RecordedBy;

            await _context.SaveChangesAsync();

            return new CRResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
                WithCR = report.WithCR,
                WithoutCR = report.WithoutCR,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<CRResponseDto>> GetCRAsync(string barangay, int year)
        {
            var query = _context.CRReports.AsQueryable();
            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            if (year != 0)
            {
                query = query.Where(r => r.Year == year);
            }

            var reports = await query
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new CRResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                HouseholdName = r.HouseholdName,
                WithCR = r.WithCR,
                WithoutCR = r.WithoutCR,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<bool> DeleteCRAsync(int id)
        {
            var report = await _context.CRReports.FindAsync(id);
            if (report == null) return false;
            _context.CRReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        // ==================== BACKYARD GARDENING ====================
        public async Task<BackyardGardeningResponseDto> CreateBackyardGardeningAsync(BackyardGardeningEntryDto dto)
        {
            var exists = await CheckBackyardGardeningDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            var report = new BackyardGardeningReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                HouseholdName = dto.HouseholdName,
                HasGarden = dto.HasGarden,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow
            };

            _context.BackyardGardeningReports.Add(report);
            await _context.SaveChangesAsync();

            return new BackyardGardeningResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
                HasGarden = report.HasGarden,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<BackyardGardeningResponseDto> UpdateBackyardGardeningAsync(int id, BackyardGardeningEntryDto dto)
        {
            var report = await _context.BackyardGardeningReports.FindAsync(id);
            if (report == null)
                throw new KeyNotFoundException($"Record with ID {id} not found");

            var exists = await CheckBackyardGardeningDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok, id);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            report.Barangay = dto.Barangay;
            report.Purok = dto.Purok;
            report.HouseholdName = dto.HouseholdName;
            report.HasGarden = dto.HasGarden;
            report.Year = dto.Year;
            report.RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow;
            report.RecordedBy = dto.RecordedBy;

            await _context.SaveChangesAsync();

            return new BackyardGardeningResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
                HasGarden = report.HasGarden,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<BackyardGardeningResponseDto>> GetBackyardGardeningAsync(string barangay, int year)
        {
            var query = _context.BackyardGardeningReports.AsQueryable();

            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            if (year != 0)
            {
                query = query.Where(r => r.Year == year);
            }

            var reports = await query
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new BackyardGardeningResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                HouseholdName = r.HouseholdName,
                HasGarden = r.HasGarden,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<bool> DeleteBackyardGardeningAsync(int id)
        {
            var report = await _context.BackyardGardeningReports.FindAsync(id);
            if (report == null) return false;
            _context.BackyardGardeningReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        // ==================== PREGNANT WOMEN ====================
        public async Task<PregnantWomenResponseDto> CreatePregnantWomenAsync(PregnantWomenEntryDto dto)
        {
            var exists = await CheckPregnantWomenDuplicateAsync(dto.WomanName, dto.Barangay, dto.Purok);
            if (exists)
            {
                throw new InvalidOperationException($"A woman named '{dto.WomanName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            var report = new PregnantWomenReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                WomanName = dto.WomanName,
                Weight = dto.Weight,
                Height = dto.Height,
                BMI = dto.BMI,
                BMICategory = dto.BMICategory,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow
            };

            _context.PregnantWomenReports.Add(report);
            await _context.SaveChangesAsync();

            return new PregnantWomenResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                WomanName = report.WomanName,
                Weight = report.Weight,
                Height = report.Height,
                BMI = report.BMI,
                BMICategory = report.BMICategory,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<PregnantWomenResponseDto> UpdatePregnantWomenAsync(int id, PregnantWomenEntryDto dto)
        {
            var report = await _context.PregnantWomenReports.FindAsync(id);
            if (report == null)
                throw new KeyNotFoundException($"Record with ID {id} not found");

            var exists = await CheckPregnantWomenDuplicateAsync(dto.WomanName, dto.Barangay, dto.Purok, id);
            if (exists)
            {
                throw new InvalidOperationException($"A woman named '{dto.WomanName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            report.Barangay = dto.Barangay;
            report.Purok = dto.Purok;
            report.WomanName = dto.WomanName;
            report.Weight = dto.Weight;
            report.Height = dto.Height;
            report.BMI = dto.BMI;
            report.BMICategory = dto.BMICategory;
            report.Year = dto.Year;
            report.RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow;
            report.RecordedBy = dto.RecordedBy;

            await _context.SaveChangesAsync();

            return new PregnantWomenResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                WomanName = report.WomanName,
                Weight = report.Weight,
                Height = report.Height,
                BMI = report.BMI,
                BMICategory = report.BMICategory,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<PregnantWomenResponseDto>> GetPregnantWomenAsync(string barangay, int year)
        {
            var query = _context.PregnantWomenReports.AsQueryable();

            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            if (year != 0)
            {
                query = query.Where(r => r.Year == year);
            }

            var reports = await query
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new PregnantWomenResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                WomanName = r.WomanName,
                Weight = r.Weight,
                Height = r.Height,
                BMI = r.BMI,
                BMICategory = r.BMICategory,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<bool> DeletePregnantWomenAsync(int id)
        {
            var report = await _context.PregnantWomenReports.FindAsync(id);
            if (report == null) return false;
            _context.PregnantWomenReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        // ==================== VEGETABLE SEEDS ====================
        public async Task<VegetableSeedResponseDto> CreateVegetableSeedAsync(VegetableSeedEntryDto dto)
        {
            var exists = await CheckVegetableSeedDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            var report = new VegetableSeedReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                HouseholdName = dto.HouseholdName,
                SeedTypes = dto.SeedTypes,
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow
            };

            _context.VegetableSeedReports.Add(report);
            await _context.SaveChangesAsync();

            return new VegetableSeedResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
                SeedTypes = report.SeedTypes,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<VegetableSeedResponseDto> UpdateVegetableSeedAsync(int id, VegetableSeedEntryDto dto)
        {
            var report = await _context.VegetableSeedReports.FindAsync(id);
            if (report == null)
                throw new KeyNotFoundException($"Record with ID {id} not found");

            var exists = await CheckVegetableSeedDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok, id);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            report.Barangay = dto.Barangay;
            report.Purok = dto.Purok;
            report.HouseholdName = dto.HouseholdName;
            report.SeedTypes = dto.SeedTypes;
            report.Year = dto.Year;
            report.RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow;
            report.RecordedBy = dto.RecordedBy;

            await _context.SaveChangesAsync();

            return new VegetableSeedResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
                SeedTypes = report.SeedTypes,
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<VegetableSeedResponseDto>> GetVegetableSeedAsync(string barangay, int year)
        {
            var query = _context.VegetableSeedReports.AsQueryable();

            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            if (year != 0)
            {
                query = query.Where(r => r.Year == year);
            }

            var reports = await query
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new VegetableSeedResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                HouseholdName = r.HouseholdName,
                SeedTypes = r.SeedTypes,
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<bool> DeleteVegetableSeedAsync(int id)
        {
            var report = await _context.VegetableSeedReports.FindAsync(id);
            if (report == null)
                return false;

            _context.VegetableSeedReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        // ==================== ANIMAL DISPERSAL ====================
        public async Task<AnimalDispersalResponseDto> CreateAnimalDispersalAsync(AnimalDispersalEntryDto dto)
        {
            var exists = await CheckAnimalDispersalDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            var report = new AnimalDispersalReport
            {
                Barangay = dto.Barangay,
                Purok = dto.Purok,
                HouseholdName = dto.HouseholdName,
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
                Year = dto.Year,
                RecordedBy = dto.RecordedBy,
                RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow
            };

            _context.AnimalDispersalReports.Add(report);
            await _context.SaveChangesAsync();

            return new AnimalDispersalResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
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
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<AnimalDispersalResponseDto> UpdateAnimalDispersalAsync(int id, AnimalDispersalEntryDto dto)
        {
            var report = await _context.AnimalDispersalReports.FindAsync(id);
            if (report == null)
                throw new KeyNotFoundException($"Record with ID {id} not found");

            var exists = await CheckAnimalDispersalDuplicateAsync(dto.HouseholdName, dto.Barangay, dto.Purok, id);
            if (exists)
            {
                throw new InvalidOperationException($"A household named '{dto.HouseholdName}' already exists in {dto.Barangay}, Purok {dto.Purok}");
            }

            report.Barangay = dto.Barangay;
            report.Purok = dto.Purok;
            report.HouseholdName = dto.HouseholdName;
            report.ChickenMale = dto.ChickenMale;
            report.ChickenFemale = dto.ChickenFemale;
            report.PigMale = dto.PigMale;
            report.PigFemale = dto.PigFemale;
            report.GoatMale = dto.GoatMale;
            report.GoatFemale = dto.GoatFemale;
            report.CowMale = dto.CowMale;
            report.CowFemale = dto.CowFemale;
            report.CarabaoMale = dto.CarabaoMale;
            report.CarabaoFemale = dto.CarabaoFemale;
            report.Year = dto.Year;
            report.RecordedDate = dto.RecordedDate != DateTime.MinValue ? dto.RecordedDate : DateTime.UtcNow;
            report.RecordedBy = dto.RecordedBy;

            await _context.SaveChangesAsync();

            return new AnimalDispersalResponseDto
            {
                Id = report.Id,
                Barangay = report.Barangay,
                Purok = report.Purok,
                HouseholdName = report.HouseholdName,
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
                Year = report.Year,
                RecordedBy = report.RecordedBy,
                RecordedDate = report.RecordedDate
            };
        }

        public async Task<List<AnimalDispersalResponseDto>> GetAnimalDispersalAsync(string barangay, int year)
        {
            var query = _context.AnimalDispersalReports.AsQueryable();
            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            if (year != 0)
            {
                query = query.Where(r => r.Year == year);
            }

            var reports = await query
                .OrderBy(r => r.Purok)
                .ToListAsync();

            return reports.Select(r => new AnimalDispersalResponseDto
            {
                Id = r.Id,
                Barangay = r.Barangay,
                Purok = r.Purok,
                HouseholdName = r.HouseholdName,
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
                Year = r.Year,
                RecordedBy = r.RecordedBy,
                RecordedDate = r.RecordedDate
            }).ToList();
        }

        public async Task<bool> DeleteAnimalDispersalAsync(int id)
        {
            var report = await _context.AnimalDispersalReports.FindAsync(id);
            if (report == null) return false;
            _context.AnimalDispersalReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        // ==================== DUPLICATE CHECK METHODS ====================

        public async Task<bool> CheckAnimalRaisingDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null)
        {
            var query = _context.AnimalRaisingReports
                .Where(r => r.HouseholdName.ToLower() == householdName.ToLower()
                    && r.Barangay == barangay
                    && r.Purok == purok);

            if (excludeId.HasValue)
            {
                query = query.Where(r => r.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> CheckAnimalDispersalDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null)
        {
            var query = _context.AnimalDispersalReports
                .Where(r => r.HouseholdName.ToLower() == householdName.ToLower()
                    && r.Barangay == barangay
                    && r.Purok == purok);

            if (excludeId.HasValue)
            {
                query = query.Where(r => r.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> CheckPotableWaterDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null)
        {
            var query = _context.PotableWaterReports
                .Where(r => r.HouseholdName.ToLower() == householdName.ToLower()
                    && r.Barangay == barangay
                    && r.Purok == purok);

            if (excludeId.HasValue)
            {
                query = query.Where(r => r.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> CheckCRDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null)
        {
            var query = _context.CRReports
                .Where(r => r.HouseholdName.ToLower() == householdName.ToLower()
                    && r.Barangay == barangay
                    && r.Purok == purok);

            if (excludeId.HasValue)
            {
                query = query.Where(r => r.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> CheckBackyardGardeningDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null)
        {
            var query = _context.BackyardGardeningReports
                .Where(r => r.HouseholdName.ToLower() == householdName.ToLower()
                    && r.Barangay == barangay
                    && r.Purok == purok);

            if (excludeId.HasValue)
            {
                query = query.Where(r => r.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> CheckPregnantWomenDuplicateAsync(string womanName, string barangay, int purok, int? excludeId = null)
        {
            var query = _context.PregnantWomenReports
                .Where(r => r.WomanName.ToLower() == womanName.ToLower()
                    && r.Barangay == barangay
                    && r.Purok == purok);

            if (excludeId.HasValue)
            {
                query = query.Where(r => r.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> CheckVegetableSeedDuplicateAsync(string householdName, string barangay, int purok, int? excludeId = null)
        {
            var query = _context.VegetableSeedReports
                .Where(r => r.HouseholdName.ToLower() == householdName.ToLower()
                    && r.Barangay == barangay
                    && r.Purok == purok);

            if (excludeId.HasValue)
            {
                query = query.Where(r => r.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> CheckIodizedSaltDuplicateAsync(string? storeName, string barangay, int purok, int? excludeId = null)
        {
            var query = _context.IodizedSaltReports
                .Where(r => (r.StoreName ?? string.Empty).ToLower() == (storeName ?? string.Empty).ToLower()
                    && r.Barangay == barangay
                    && r.Purok == purok);

            if (excludeId.HasValue)
            {
                query = query.Where(r => r.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }
    }
}