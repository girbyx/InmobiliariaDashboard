using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IMonetaryAgentService : IBaseService<MonetaryAgent>
    {
        IEnumerable<MonetaryAgent> GetByProject(int id);
    }

    public class MonetaryAgentService : IMonetaryAgentService
    {
        private readonly IApplicationDbContext _dbContext;

        public MonetaryAgentService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MonetaryAgent> GetAll()
        {
            var records = _dbContext.Set<MonetaryAgent>()
                .Include(x => x.Enterprise)
                .ToList();
            return records;
        }

        public IEnumerable<MonetaryAgent> GetAllForResolver()
        {
            var records = _dbContext.Set<MonetaryAgent>().ToList();
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