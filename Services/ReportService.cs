using Microsoft.EntityFrameworkCore;
using Nutrition_backend.Data;
using Nutrition_backend.Models;
using Nutrition_backend.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrition_backend.Services
{
    public interface IReportService
    {
        Task<VitaminAReport> CreateReportAsync(ReportDto reportDto, int userId);
        Task<VitaminAReport> GetReportByIdAsync(int id);
        Task<List<VitaminAReport>> GetReportsAsync(string? barangay = null, string? status = null);
        Task<VitaminAReport> UpdateReportAsync(int id, ReportDto reportDto, int userId);
        Task<VitaminAReport> ApproveReportAsync(int id, int adminId, string? remarks = null);
        Task<bool> DeleteReportAsync(int id);
        Task<List<VitaminAReport>> GetUserReportsAsync(int userId);
        Task<OverallReportDto> GetOverallReportAsync(string? quarter = null, int? year = null);
        Task<ReportSummaryDto> GetBarangaySummaryAsync(string barangay);
        Task<ReportSummaryDto> GetReportSummaryAsync(string? barangay = null);
    }

    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VitaminAReport> CreateReportAsync(ReportDto reportDto, int userId)
{
    var report = new VitaminAReport
    {
        Barangay = reportDto.Barangay,
        Purok = reportDto.Purok,
        Months6To11 = reportDto.Months6To11,
        Months12To59 = reportDto.Months12To59,
        UnderweightSUW = reportDto.UnderweightSUW,
        ReportedByUserId = userId,
        ReportedDate = DateTime.UtcNow,
        Status = "pending",
        Remarks = reportDto.Remarks,
        Quarter = reportDto.Quarter,
        Year = reportDto.Year ?? DateTime.UtcNow.Year
    };

    _context.VitaminAReports.Add(report);
    await _context.SaveChangesAsync();

    return report;
}

        public async Task<VitaminAReport> GetReportByIdAsync(int id)
        {
            var report = await _context.VitaminAReports
                .Include(r => r.ReportedBy)
                .Include(r => r.ApprovedBy)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (report == null)
            {
                throw new KeyNotFoundException($"Report with ID {id} not found");
            }

            return report;
        }

        public async Task<List<VitaminAReport>> GetReportsAsync(string? barangay = null, string? status = null)
        {
            var query = _context.VitaminAReports
                .Include(r => r.ReportedBy)
                .Include(r => r.ApprovedBy)
                .AsQueryable();

            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(r => r.Status == status);
            }

            return await query
                .OrderByDescending(r => r.ReportedDate)
                .ToListAsync();
        }

        public async Task<VitaminAReport> UpdateReportAsync(int id, ReportDto reportDto, int userId)
        {
            var report = await GetReportByIdAsync(id);

            if (report.Status == "approved")
            {
                throw new InvalidOperationException("Cannot update an approved report");
            }

            report.Barangay = reportDto.Barangay;
            report.Purok = reportDto.Purok;
            report.Months6To11 = reportDto.Months6To11;
            report.Months12To59 = reportDto.Months12To59;
            report.UnderweightSUW = reportDto.UnderweightSUW;
            report.Remarks = reportDto.Remarks;

            await _context.SaveChangesAsync();

            return report;
        }

        public async Task<VitaminAReport> ApproveReportAsync(int id, int adminId, string? remarks = null)
        {
            var report = await GetReportByIdAsync(id);

            if (report.Status == "approved")
            {
                throw new InvalidOperationException("Report is already approved");
            }

            report.Status = "approved";
            report.ApprovedByUserId = adminId;
            report.ApprovedDate = DateTime.UtcNow;
            report.Remarks = remarks ?? report.Remarks;

            await _context.SaveChangesAsync();

            return report;
        }

        public async Task<bool> DeleteReportAsync(int id)
        {
            var report = await _context.VitaminAReports.FindAsync(id);
            
            if (report == null)
            {
                return false;
            }

            _context.VitaminAReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<VitaminAReport>> GetUserReportsAsync(int userId)
        {
            return await _context.VitaminAReports
                .Include(r => r.ReportedBy)
                .Include(r => r.ApprovedBy)
                .Where(r => r.ReportedByUserId == userId)
                .OrderByDescending(r => r.ReportedDate)
                .ToListAsync();
        }

        public async Task<OverallReportDto> GetOverallReportAsync(string? quarter = null, int? year = null)
        {
            var targetYear = year ?? DateTime.UtcNow.Year;
            
            var query = _context.VitaminAReports
                .Where(r => r.Year == targetYear && r.Status == "approved")
                .AsQueryable();

            if (!string.IsNullOrEmpty(quarter))
            {
                query = query.Where(r => r.Quarter == quarter);
            }

            var reports = await query
                .Include(r => r.ReportedBy)
                .Include(r => r.ApprovedBy)
                .ToListAsync();

            var overallReport = new OverallReportDto
            {
                Year = targetYear.ToString(),
                Quarter = quarter,
                GeneratedDate = DateTime.UtcNow
            };

            var barangayGroups = reports
                .Where(r => r.Purok == 0)
                .GroupBy(r => r.Barangay)
                .ToList();

            var allBarangays = BarangayData.AllBarangays;

            foreach (var barangay in allBarangays)
            {
                var barangayReports = barangayGroups.FirstOrDefault(g => g.Key == barangay);
                
                var barangayDto = new BarangayReportDto
                {
                    Barangay = barangay,
                    Months6To11 = barangayReports?.Sum(r => r.Months6To11) ?? 0,
                    Months12To59 = barangayReports?.Sum(r => r.Months12To59) ?? 0,
                    UnderweightSUW = barangayReports?.Sum(r => r.UnderweightSUW) ?? 0,
                    Status = barangayReports != null ? "Completed" : "No Report",
                    ReportedDate = barangayReports?.FirstOrDefault()?.ReportedDate
                };

                var purokDetails = reports
                    .Where(r => r.Barangay == barangay && r.Purok > 0)
                    .OrderBy(r => r.Purok)
                    .Select(r => new PurokDetailDto
                    {
                        Purok = r.Purok,
                        Months6To11 = r.Months6To11,
                        Months12To59 = r.Months12To59,
                        UnderweightSUW = r.UnderweightSUW
                    })
                    .ToList();

                barangayDto.PurokDetails = purokDetails;
                overallReport.BarangayReports.Add(barangayDto);
            }

            overallReport.OverallTotal = new OverallTotalDto
            {
                TotalMonths6To11 = overallReport.BarangayReports.Sum(b => b.Months6To11),
                TotalMonths12To59 = overallReport.BarangayReports.Sum(b => b.Months12To59),
                TotalUnderweightSUW = overallReport.BarangayReports.Sum(b => b.UnderweightSUW),
                TotalBarangays = overallReport.BarangayReports.Count,
                ApprovedCount = overallReport.BarangayReports.Count(b => b.Status == "Completed"),
                PendingCount = overallReport.BarangayReports.Count(b => b.Status == "No Report")
            };

            return overallReport;
        }

        public async Task<ReportSummaryDto> GetReportSummaryAsync(string? barangay = null)
        {
            var query = _context.VitaminAReports
                .Where(r => r.Status == "approved")
                .AsQueryable();

            if (!string.IsNullOrEmpty(barangay))
            {
                query = query.Where(r => r.Barangay == barangay);
            }

            var reports = await query.ToListAsync();

            var summary = new ReportSummaryDto
            {
                Barangay = barangay ?? "All Barangays",
                TotalReports = reports.Count,
                TotalMonths6To11 = reports.Sum(r => r.Months6To11),
                TotalMonths12To59 = reports.Sum(r => r.Months12To59),
                TotalUnderweightSUW = reports.Sum(r => r.UnderweightSUW),
                TotalChildren = reports.Sum(r => r.Months6To11 + r.Months12To59 + r.UnderweightSUW),
                ReportsByPurok = reports
                    .Where(r => r.Purok > 0)
                    .GroupBy(r => r.Purok)
                    .Select(g => new PurokSummaryDto
                    {
                        Purok = g.Key,
                        TotalChildren = g.Sum(r => r.Months6To11 + r.Months12To59 + r.UnderweightSUW),
                        Count = g.Count()
                    })
                    .ToList()
            };

            return summary;
        }

        public async Task<ReportSummaryDto> GetBarangaySummaryAsync(string barangay)
        {
            var reports = await _context.VitaminAReports
                .Where(r => r.Barangay == barangay && r.Status == "approved")
                .ToListAsync();

            var summary = new ReportSummaryDto
            {
                Barangay = barangay,
                TotalReports = reports.Count,
                TotalMonths6To11 = reports.Sum(r => r.Months6To11),
                TotalMonths12To59 = reports.Sum(r => r.Months12To59),
                TotalUnderweightSUW = reports.Sum(r => r.UnderweightSUW),
                TotalChildren = reports.Sum(r => r.Months6To11 + r.Months12To59 + r.UnderweightSUW),
                ReportsByPurok = reports
                    .Where(r => r.Purok > 0)
                    .GroupBy(r => r.Purok)
                    .Select(g => new PurokSummaryDto
                    {
                        Purok = g.Key,
                        TotalChildren = g.Sum(r => r.Months6To11 + r.Months12To59 + r.UnderweightSUW),
                        Count = g.Count()
                    })
                    .OrderBy(p => p.Purok)
                    .ToList()
            };

            return summary;
        }
    }
}