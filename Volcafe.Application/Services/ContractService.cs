using Volcafe.Core.Entities;
using Volcafe.Core.Interfaces;

namespace Volcafe.Core.Application
{
    public class ContractService : IContractService
    {
        private IContractRepository _contractRepository;
        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;

        }

        public async Task<List<ContractDetail>> GetContractsByAgentId(string agentId)
        {
            var contractDetails = await _contractRepository.GetContractsByAgentId(agentId);
            return contractDetails;
        }

        public async Task<List<ContractDetail>> GetContractsByReviewer(string reviewer)
        {
            var contractDetails = await _contractRepository.GetContractsByReviewer(reviewer);
            return contractDetails;
        }

        public async Task<ContractDetail> GetContractDetails(string contractId)
        {
            var contractDetails = await _contractRepository.GetContractDetails(contractId);
            return contractDetails;
        }
    }
}
