using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ICostService : IBaseService<Cost>
    {
    }

    public class CostService : ICostService
    {
        private readonly IApplicationDbContext _dbContext;

        public CostService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Cost> GetAll()
        {
            var records = _dbContext.Set<Cost>()
                .Include(x => x.CostType)
                .Include(x => x.Project)
                .Include(x => x.MonetaryAgent)
                .ToList();
            return records;
        }

        public IEnumerable<Cost> GetAllForResolver()
        {
            var records = _dbContext.Set<Cost>().ToList();
            return records;
        }
    }
}