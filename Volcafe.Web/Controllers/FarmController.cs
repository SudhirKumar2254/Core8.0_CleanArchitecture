using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Volcafe.Services.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly ILogger<FarmController> _logger;

        public FarmController(ILogger<FarmController> logger)
        {
            _logger = logger;
        }

        [HttpGet("AddEditFarmDetails/{contractId}")]
        public async Task<ObjectResult> AddEditFarmDetails(int contractId, string[] farmDetails)
        {
            try
            {
                _logger.LogInformation("Inside AddEditFarmDetails");
                string response = "";
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in AddEditFarmDetails. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);

            }
        }
    }
}
