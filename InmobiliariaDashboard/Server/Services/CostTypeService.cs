using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ICostTypeService : IBaseService<CostType>
    {
    }

    public class CostTypeService : ICostTypeService
    {
        private readonly IApplicationDbContext _dbContext;

        public CostTypeService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CostType> GetAll()
        {
            var records = _dbContext.Set<CostType>()
                .Include(x => x.Costs)
                .ToList();
            return records;
        }

        public IEnumerable<CostType> GetAllForResolver()
        {
            var records = _dbContext.Set<CostType>().ToList();
            return records;
        }
    }
}