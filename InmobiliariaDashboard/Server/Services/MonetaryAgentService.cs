using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IMonetaryAgentService : IBaseService<BankAccount, object>
    {
        IEnumerable<BankAccount> GetByEnterprise(int id);
        IEnumerable<BankAccount> GetByProject(int id);
    }

    public class MonetaryAgentService : BaseService<BankAccount, object>, IMonetaryAgentService
    {
        private readonly IApplicationDbContext _dbContext;

        public MonetaryAgentService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) :
            base(dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<BankAccount> GetByEnterprise(int id)
        {
            var records = _dbContext.Set<BankAccount>()
                .Where(x => x.People.Id == id)
                .ToList();
            return records;
        }

        public IEnumerable<BankAccount> GetByProject(int id)
        {
            var records = _dbContext.Set<BankAccount>()
                .Where(x => x.People.Projects.Any(y => y.Id == id))
                .ToList();
            return records;
        }
    }
}