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
        public async Task<IActionResult> GetIodizedSalt(string barangay)
        {
            try
            {
                var result = await _service.GetIodizedSaltAsync(barangay);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

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
    }
}