using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Nutrition_backend.DTOs;
using Nutrition_backend.Services;

namespace Nutrition_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        private int GetCurrentUserId()
{
    var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
        ?? User.FindFirst("id")
        ?? User.FindFirst("sub")
        ?? User.FindFirst("userId")
        ?? User.FindFirst("nameid");

    if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
    {
        throw new UnauthorizedAccessException("User ID claim not found or invalid in token");
    }

    return userId;
}

        private string GetCurrentUserRole()
        {
            var roleClaim = User.FindFirst(ClaimTypes.Role);
            return roleClaim?.Value ?? "staff";
        }

        private string GetCurrentUserBarangay()
        {
            var barangayClaim = User.FindFirst("Barangay");
            return barangayClaim?.Value ?? string.Empty;
        }

        [HttpPost]
public async Task<IActionResult> CreateReport([FromBody] ReportDto reportDto)
{
    try
    {
        var userId = GetCurrentUserId();
        var userRole = GetCurrentUserRole();
        var userBarangay = GetCurrentUserBarangay();

        if (userRole == "staff" && reportDto.Barangay != userBarangay)
        {
            return Forbid("You can only report for your assigned barangay");
        }

        var report = await _reportService.CreateReportAsync(reportDto, userId);
        return Ok(report);
    }
    catch (UnauthorizedAccessException ex)
    {
        return Unauthorized(new { message = ex.Message });
    }
    catch (InvalidOperationException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
    catch (Exception ex)
    {
        Console.WriteLine("=== CreateReport FAILED ===");
        Console.WriteLine(ex.ToString()); // full exception + stack trace, not just .Message
        Console.WriteLine("===========================");
        return BadRequest(new { message = ex.Message });
    }
}

        [HttpGet]
        public async Task<IActionResult> GetReports([FromQuery] string? barangay = null, [FromQuery] string? status = null)
        {
            try
            {
                var userRole = GetCurrentUserRole();
                var userBarangay = GetCurrentUserBarangay();

                // Staff can only see their barangay
                if (userRole == "staff")
                {
                    barangay = userBarangay;
                }

                var reports = await _reportService.GetReportsAsync(barangay, status);
                return Ok(reports);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            try
            {
                var report = await _reportService.GetReportByIdAsync(id);
                
                var userRole = GetCurrentUserRole();
                var userBarangay = GetCurrentUserBarangay();

                // Staff can only see their barangay reports
                if (userRole == "staff" && report.Barangay != userBarangay)
                {
                    return Forbid("You can only view reports for your barangay");
                }

                return Ok(report);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReport(int id, [FromBody] ReportDto reportDto)
        {
            try
            {
                var userId = GetCurrentUserId();
                var userRole = GetCurrentUserRole();
                var userBarangay = GetCurrentUserBarangay();

                // Get existing report
                var existingReport = await _reportService.GetReportByIdAsync(id);

                // Staff can only update their own reports for their barangay
                if (userRole == "staff")
                {
                    if (existingReport.Barangay != userBarangay)
                    {
                        return Forbid("You can only update reports for your barangay");
                    }
                    if (existingReport.ReportedByUserId != userId)
                    {
                        return Forbid("You can only update your own reports");
                    }
                }

                var report = await _reportService.UpdateReportAsync(id, reportDto, userId);
                return Ok(report);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/approve")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ApproveReport(int id, [FromBody] string? remarks = null)
        {
            try
            {
                var adminId = GetCurrentUserId();
                var report = await _reportService.ApproveReportAsync(id, adminId, remarks);
                return Ok(report);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            try
            {
                var userRole = GetCurrentUserRole();
                var userId = GetCurrentUserId();
                var userBarangay = GetCurrentUserBarangay();

                // Get existing report
                var existingReport = await _reportService.GetReportByIdAsync(id);

                // Staff can only delete their own reports for their barangay
                if (userRole == "staff")
                {
                    if (existingReport.Barangay != userBarangay)
                    {
                        return Forbid("You can only delete reports for your barangay");
                    }
                    if (existingReport.ReportedByUserId != userId)
                    {
                        return Forbid("You can only delete your own reports");
                    }
                }

                var result = await _reportService.DeleteReportAsync(id);
                if (result)
                {
                    return Ok(new { message = "Report deleted successfully" });
                }
                return NotFound(new { message = "Report not found" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary([FromQuery] string? barangay = null)
        {
            try
            {
                var userRole = GetCurrentUserRole();
                var userBarangay = GetCurrentUserBarangay();

                // Staff can only see their barangay summary
                if (userRole == "staff")
                {
                    barangay = userBarangay;
                }

                var summary = await _reportService.GetReportSummaryAsync(barangay);
                return Ok(summary);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("overall")]
public async Task<IActionResult> GetOverallReport([FromQuery] string? quarter = null, [FromQuery] int? year = null)
{
    try
    {
        var userRole = GetCurrentUserRole();
        var userBarangay = GetCurrentUserBarangay();

        // Staff can only see overall report for their barangay
        if (userRole == "staff")
        {
            var summary = await _reportService.GetBarangaySummaryAsync(userBarangay);
            return Ok(summary);
        }

        var report = await _reportService.GetOverallReportAsync(quarter, year);
        return Ok(report);
    }
    catch (Exception ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}

[HttpGet("barangay/{barangay}/summary")]
public async Task<IActionResult> GetBarangaySummary(string barangay)
{
    try
    {
        var userRole = GetCurrentUserRole();
        var userBarangay = GetCurrentUserBarangay();

        // Staff can only see their barangay
        if (userRole == "staff" && barangay != userBarangay)
        {
            return Forbid("You can only view your barangay summary");
        }

        var summary = await _reportService.GetBarangaySummaryAsync(barangay);
        return Ok(summary);
    }
    catch (Exception ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}

        [HttpGet("my-reports")]
        public async Task<IActionResult> GetMyReports()
        {
            try
            {
                var userId = GetCurrentUserId();
                var reports = await _reportService.GetUserReportsAsync(userId);
                return Ok(reports);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}