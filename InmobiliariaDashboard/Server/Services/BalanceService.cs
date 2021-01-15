using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IBalanceService
    {
        IEnumerable<People> GetEnterpriseBalances();
        IEnumerable<BankAccount> GetMonetaryAgentBalances();
    }

    public class BalanceService : IBalanceService
    {
        private readonly IApplicationDbContext _dbContext;

        public BalanceService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<People> GetEnterpriseBalances()
        {
            var records = _dbContext.Set<People>()
                .Include(x => x.Assets)
                .Include(x => x.Costs)
                .Include(x => x.Gains)
                .Include(x => x.Losses)
                .Include(x => x.Projects).ThenInclude(x => x.Costs)
                .Include(x => x.Projects).ThenInclude(x => x.Gains)
                .Include(x => x.Projects).ThenInclude(x => x.Losses)
                .ToList();
            return records;
        }

        public IEnumerable<BankAccount> GetMonetaryAgentBalances()
        {
            var records = _dbContext.Set<BankAccount>()
                .Include(x => x.Costs)
                .Include(x => x.Gains)
                .Include(x => x.Losses)
                .ToList();
            return records;
        }
    }
}