using Volcafe.Core.Entities;

namespace Volcafe.Core.Interfaces
{
    public interface IContractService
    {
        Task<List<ContractDetail>> GetContractsByAgentId(string agentId);
        Task<List<ContractDetail>> GetContractsByReviewer(string reviewer);
        Task<ContractDetail> GetContractDetails(string contractId);
    }
}
