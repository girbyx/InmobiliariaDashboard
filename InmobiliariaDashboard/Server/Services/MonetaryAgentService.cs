using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IMonetaryAgentService : IBaseService<MonetaryAgent, object>
    {
        IEnumerable<MonetaryAgent> GetByEnterprise(int id);
        IEnumerable<MonetaryAgent> GetByProject(int id);
    }

    public class MonetaryAgentService : BaseService<MonetaryAgent, object>, IMonetaryAgentService
    {
        private readonly IApplicationDbContext _dbContext;

        public MonetaryAgentService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) :
            base(dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MonetaryAgent> GetByEnterprise(int id)
        {
            var records = _dbContext.Set<MonetaryAgent>()
                .Where(x => x.Enterprise.Id == id)
                .ToList();
            return records;
        }

        public IEnumerable<MonetaryAgent> GetByProject(int id)
        {
            var records = _dbContext.Set<MonetaryAgent>()
                .Where(x => x.Enterprise.Projects.Any(y => y.Id == id))
                .ToList();
            return records;
        }
    }
}