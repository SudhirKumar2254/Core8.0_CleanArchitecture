using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Volcafe.Application.DTO;
using Volcafe.Core.Entities;
using Volcafe.Core.Interfaces;

namespace Volcafe.Services.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public DocumentController(ILogger<DocumentController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("UploadDocument/{contractId}")]
        public async Task<ObjectResult> UploadDocument(int contractId)
        {
            try
            {
                _logger.LogInformation("Inside UploadDocument");
                string response = "";
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in UploadDocument. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("DownloadDocument/{documentId}")]
        public async Task<ObjectResult> DownloadDocument(int documentId)
        {
            try
            {
                _logger.LogInformation("Inside DownloadDocument");
                var allUsers = await _userService.GetAllUsers();
                var userList = _mapper.Map<List<User>, List<UserDTO>>(allUsers);
                string response = JsonSerializer.Serialize(userList.Select(x => x.Name + x.Email));
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in DownloadDocument. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
