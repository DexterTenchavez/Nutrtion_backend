using System.Collections.Generic;

namespace Nutrition_backend.DTOs
{
    public class OverallReportDto
    {
        public string Year { get; set; } = DateTime.UtcNow.Year.ToString();
        public string? Quarter { get; set; }
        public DateTime GeneratedDate { get; set; } = DateTime.UtcNow;
        public List<BarangayReportDto> BarangayReports { get; set; } = new();
        public OverallTotalDto OverallTotal { get; set; } = new();
        public string PreparedBy { get; set; } = string.Empty;
        public string NotedBy { get; set; } = string.Empty;
    }

    public class BarangayReportDto
    {
        public string Barangay { get; set; } = string.Empty;
        public int Months6To11 { get; set; }
        public int Months12To59 { get; set; }
        public int UnderweightSUW { get; set; }
        public int Total => Months6To11 + Months12To59 + UnderweightSUW;
        public string? Status { get; set; }
        public DateTime? ReportedDate { get; set; }
        public List<PurokDetailDto> PurokDetails { get; set; } = new();
    }

    public class PurokDetailDto
    {
        public int Purok { get; set; }
        public int Months6To11 { get; set; }
        public int Months12To59 { get; set; }
        public int UnderweightSUW { get; set; }
        public int Total => Months6To11 + Months12To59 + UnderweightSUW;
    }

    public class OverallTotalDto
    {
        public int TotalMonths6To11 { get; set; }
        public int TotalMonths12To59 { get; set; }
        public int TotalUnderweightSUW { get; set; }
        public int GrandTotal => TotalMonths6To11 + TotalMonths12To59 + TotalUnderweightSUW;
        public int TotalBarangays { get; set; }
        public int ApprovedCount { get; set; }
        public int PendingCount { get; set; }
    }
}