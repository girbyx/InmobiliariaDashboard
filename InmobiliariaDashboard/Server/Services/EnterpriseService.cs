using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IEnterpriseService : IBaseService<Models.Enterprise>
    {
    }

    public class EnterpriseService : IEnterpriseService
    {
        private readonly IApplicationDbContext _dbContext;

        public EnterpriseService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.Enterprise> GetAll()
        {
            var records = _dbContext.Set<Models.Enterprise>()
                .Include(x => x.Projects)
                .Include(x => x.MonetaryAgents)
                .ToList();
            return records;
        }

        public IEnumerable<Models.Enterprise> GetAllForResolver()
        {
            var records = _dbContext.Set<Models.Enterprise>().ToList();
            return records;
        }
    }
}