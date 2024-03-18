using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Volcafe.Application.DTO;
using Volcafe.Core.Entities;
using Volcafe.Core.Interfaces;

namespace Volcafe.Services.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ILogger<ContractController> _logger;
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;

        public ContractController(ILogger<ContractController> logger, IContractService contractService, IMapper mapper)
        {
            _logger = logger;
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpGet("GetContractsByAgentId/{agentId}")]
        public async Task<ObjectResult> GetContractsByAgentId(string agentId)
        {
            try
            {
                _logger.LogInformation("Inside GetContractsByAgentId");
                var contracts = await _contractService.GetContractsByAgentId(agentId);
                var contractDetails = _mapper.Map<List<ContractDetail>, List<ContractDetailDTO>>(contracts);
                string response = JsonSerializer.Serialize(contractDetails);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in GetContractsByAgentId. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet("GetContractsByReviewer/{reviewer}")]
        public async Task<ObjectResult> GetContractsByReviewer(string reviewer)
        {
            try
            {
                _logger.LogInformation("Inside GetContractsByReviewer");
                var contracts = await _contractService.GetContractsByReviewer(reviewer);
                var contractDetails = _mapper.Map<List<ContractDetail>, List<ContractDetailDTO>>(contracts);
                string response = JsonSerializer.Serialize(contractDetails);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in GetContractsByReviewer. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet("GetContractDetails/{contractId}")]
        public async Task<ObjectResult> GetContractDetails(string contractId)
        {
            try
            {
                _logger.LogInformation("Inside GetContractDetails");
                var contracts = await _contractService.GetContractDetails(contractId);
                var contractDetails = _mapper.Map<ContractDetail, ContractDetailDTO>(contracts);
                string response = JsonSerializer.Serialize(contractDetails);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in GetContractDetails. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);

            }
        }

        [HttpPost("ApproveContract/{contractId}")]
        public async Task<ObjectResult> ApproveContract(string contractId)
        {
            try
            {
                _logger.LogInformation("Inside ApproveContract");
                // var contracts = await _contractService.GetContractDetails(contractId);
                // var contractDetails = _mapper.Map<ContractDetail, ContractDetailDTO>(contracts);
                string response = ""; // JsonSerializer.Serialize(contractDetails);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in ApproveContract. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);

            }
        }

        [HttpPost("RejectContract/{contractId}")]
        public async Task<ObjectResult> RejectContract(string contractId)
        {
            try
            {
                _logger.LogInformation("Inside RejectContract");
                // var contracts = await _contractService.GetContractDetails(contractId);
                // var contractDetails = _mapper.Map<ContractDetail, ContractDetailDTO>(contracts);
                string response = ""; // JsonSerializer.Serialize(contractDetails);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in RejectContract. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);

            }
        }
    }
}
