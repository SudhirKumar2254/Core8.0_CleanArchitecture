using Microsoft.EntityFrameworkCore;
using Volcafe.Core.Entities;
using Volcafe.Core.Interfaces;
using Volcafe.Infrastructure.Data;

namespace Volcafe.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private DatabaseContext _databaseContext;
        public ContractRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<ContractDetail>> GetContractsByAgentId(string agentId)
        {
            var contractDetails = await _databaseContext.ContractDetails.Where(x => x.AgentId == agentId).Include(x => x.Status).OrderByDescending(x => x.CreatedDate).ToListAsync();
            return contractDetails;
        }

        public async Task<List<ContractDetail>> GetContractsByReviewer(string reviewer)
        {
            var contractDetails = await _databaseContext.ContractDetails.Where(x => x.Reviewer == reviewer).Include(x => x.Status).OrderByDescending(x => x.CreatedDate).ToListAsync();
            return contractDetails;
        }

        public async Task<ContractDetail> GetContractDetails(string contractId)
        {
            var contractDetails = _databaseContext.ContractDetails.Where(x => x.ContractId == contractId)
                    .Include(x => x.Status).Include(x => x.FarmDetails).Include(x => x.ContractDocuments).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
            return contractDetails;
        }
    }
}
