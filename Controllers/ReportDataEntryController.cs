using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrition_backend.DTOs;
using Nutrition_backend.Services;

namespace Nutrition_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin,staff")]
    public class ReportDataEntryController : ControllerBase
    {
        private readonly IReportDataEntryService _service;

        public ReportDataEntryController(IReportDataEntryService service)
        {
            _service = service;
        }

        // ==================== ANIMAL RAISING ====================
        [HttpPost("animal-raising")]
        public async Task<IActionResult> CreateAnimalRaising([FromBody] AnimalRaisingEntryDto dto)
        {
            try
            {
                var result = await _service.CreateAnimalRaisingAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("animal-raising/{barangay}/{year}")]
        public async Task<IActionResult> GetAnimalRaising(string barangay, int year)
        {
            try
            {
                var result = await _service.GetAnimalRaisingAsync(barangay, year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("animal-raising/{id}")]
        public async Task<IActionResult> UpdateAnimalRaising(int id, [FromBody] AnimalRaisingEntryDto dto)
        {
            try
            {
                var result = await _service.UpdateAnimalRaisingAsync(id, dto);
                return Ok(result);
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

        [HttpDelete("animal-raising/{id}")]
        public async Task<IActionResult> DeleteAnimalRaising(int id)
        {
            try
            {
                var result = await _service.DeleteAnimalRaisingAsync(id);
                if (!result)
                    return NotFound(new { message = "Record not found" });
                return Ok(new { message = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ==================== POTABLE WATER ====================
        [HttpPost("potable-water")]
        public async Task<IActionResult> CreatePotableWater([FromBody] PotableWaterEntryDto dto)
        {
            try
            {
                var result = await _service.CreatePotableWaterAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("potable-water/{barangay}/{year}")]
        public async Task<IActionResult> GetPotableWater(string barangay, int year)
        {
            try
            {
                var result = await _service.GetPotableWaterAsync(barangay, year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("potable-water/{id}")]
        public async Task<IActionResult> UpdatePotableWater(int id, [FromBody] PotableWaterEntryDto dto)
        {
            try
            {
                var result = await _service.UpdatePotableWaterAsync(id, dto);
                return Ok(result);
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

        [HttpDelete("potable-water/{id}")]
        public async Task<IActionResult> DeletePotableWater(int id)
        {
            try
            {
                var result = await _service.DeletePotableWaterAsync(id);
                if (!result)
                    return NotFound(new { message = "Record not found" });
                return Ok(new { message = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ==================== IODIZED SALT ====================
        [HttpPost("iodized-salt")]
        public async Task<IActionResult> CreateIodizedSalt([FromBody] IodizedSaltEntryDto dto)
        {
            try
            {
                var result = await _service.CreateIodizedSaltAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("iodized-salt/{barangay}")]
public async Task<IActionResult> GetIodizedSalt(string barangay, [FromQuery] int year = 0)
{
    try
    {
        var result = await _service.GetIodizedSaltAsync(barangay, year);
        return Ok(result);
    }
    catch (Exception ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}

        [HttpPut("iodized-salt/{id}")]
        public async Task<IActionResult> UpdateIodizedSalt(int id, [FromBody] IodizedSaltEntryDto dto)
        {
            try
            {
                var result = await _service.UpdateIodizedSaltAsync(id, dto);
                return Ok(result);
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

        [HttpDelete("iodized-salt/{id}")]
        public async Task<IActionResult> DeleteIodizedSalt(int id)
        {
            try
            {
                var result = await _service.DeleteIodizedSaltAsync(id);
                if (!result)
                    return NotFound(new { message = "Record not found" });
                return Ok(new { message = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ==================== CR ====================
        [HttpPost("cr")]
        public async Task<IActionResult> CreateCR([FromBody] CREntryDto dto)
        {
            try
            {
                var result = await _service.CreateCRAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("cr/{barangay}/{year}")]
        public async Task<IActionResult> GetCR(string barangay, int year)
        {
            try
            {
                var result = await _service.GetCRAsync(barangay, year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("cr/{id}")]
        public async Task<IActionResult> UpdateCR(int id, [FromBody] CREntryDto dto)
        {
            try
            {
                var result = await _service.UpdateCRAsync(id, dto);
                return Ok(result);
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

        [HttpDelete("cr/{id}")]
        public async Task<IActionResult> DeleteCR(int id)
        {
            try
            {
                var result = await _service.DeleteCRAsync(id);
                if (!result)
                    return NotFound(new { message = "Record not found" });
                return Ok(new { message = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ==================== BACKYARD GARDENING ====================
        [HttpPost("backyard-gardening")]
        public async Task<IActionResult> CreateBackyardGardening([FromBody] BackyardGardeningEntryDto dto)
        {
            try
            {
                var result = await _service.CreateBackyardGardeningAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("backyard-gardening/{barangay}/{year}")]
        public async Task<IActionResult> GetBackyardGardening(string barangay, int year)
        {
            try
            {
                var result = await _service.GetBackyardGardeningAsync(barangay, year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("backyard-gardening/{id}")]
        public async Task<IActionResult> UpdateBackyardGardening(int id, [FromBody] BackyardGardeningEntryDto dto)
        {
            try
            {
                var result = await _service.UpdateBackyardGardeningAsync(id, dto);
                return Ok(result);
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

        [HttpDelete("backyard-gardening/{id}")]
        public async Task<IActionResult> DeleteBackyardGardening(int id)
        {
            try
            {
                var result = await _service.DeleteBackyardGardeningAsync(id);
                if (!result)
                    return NotFound(new { message = "Record not found" });
                return Ok(new { message = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ==================== PREGNANT WOMEN ====================
        [HttpPost("pregnant-women")]
        public async Task<IActionResult> CreatePregnantWomen([FromBody] PregnantWomenEntryDto dto)
        {
            try
            {
                var result = await _service.CreatePregnantWomenAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("pregnant-women/{barangay}/{year}")]
        public async Task<IActionResult> GetPregnantWomen(string barangay, int year)
        {
            try
            {
                var result = await _service.GetPregnantWomenAsync(barangay, year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("pregnant-women/{id}")]
        public async Task<IActionResult> UpdatePregnantWomen(int id, [FromBody] PregnantWomenEntryDto dto)
        {
            try
            {
                var result = await _service.UpdatePregnantWomenAsync(id, dto);
                return Ok(result);
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

        [HttpDelete("pregnant-women/{id}")]
        public async Task<IActionResult> DeletePregnantWomen(int id)
        {
            try
            {
                var result = await _service.DeletePregnantWomenAsync(id);
                if (!result)
                    return NotFound(new { message = "Record not found" });
                return Ok(new { message = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ==================== VEGETABLE SEEDS ====================
        [HttpPost("vegetable-seeds")]
        public async Task<IActionResult> CreateVegetableSeed([FromBody] VegetableSeedEntryDto dto)
        {
            try
            {
                var result = await _service.CreateVegetableSeedAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("vegetable-seeds/{barangay}/{year}")]
        public async Task<IActionResult> GetVegetableSeed(string barangay, int year)
        {
            try
            {
                var result = await _service.GetVegetableSeedAsync(barangay, year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("vegetable-seeds/{id}")]
        public async Task<IActionResult> UpdateVegetableSeed(int id, [FromBody] VegetableSeedEntryDto dto)
        {
            try
            {
                var result = await _service.UpdateVegetableSeedAsync(id, dto);
                return Ok(result);
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

        [HttpDelete("vegetable-seeds/{id}")]
        public async Task<IActionResult> DeleteVegetableSeed(int id)
        {
            try
            {
                var result = await _service.DeleteVegetableSeedAsync(id);
                if (!result)
                    return NotFound(new { message = "Record not found" });
                return Ok(new { message = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ==================== ANIMAL DISPERSAL ====================
        [HttpPost("animal-dispersal")]
        public async Task<IActionResult> CreateAnimalDispersal([FromBody] AnimalDispersalEntryDto dto)
        {
            try
            {
                var result = await _service.CreateAnimalDispersalAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("animal-dispersal/{barangay}/{year}")]
        public async Task<IActionResult> GetAnimalDispersal(string barangay, int year)
        {
            try
            {
                var result = await _service.GetAnimalDispersalAsync(barangay, year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("animal-dispersal/{id}")]
        public async Task<IActionResult> UpdateAnimalDispersal(int id, [FromBody] AnimalDispersalEntryDto dto)
        {
            try
            {
                var result = await _service.UpdateAnimalDispersalAsync(id, dto);
                return Ok(result);
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

        [HttpDelete("animal-dispersal/{id}")]
        public async Task<IActionResult> DeleteAnimalDispersal(int id)
        {
            try
            {
                var result = await _service.DeleteAnimalDispersalAsync(id);
                if (!result)
                    return NotFound(new { message = "Record not found" });
                return Ok(new { message = "Record deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}