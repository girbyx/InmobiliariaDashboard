using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ICostService : IBaseService<Cost, object>
    {
    }

    public class CostService : BaseService<Cost, object>, ICostService
    {
        private readonly IApplicationDbContext _dbContext;

        public CostService(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<Cost> GetAll()
        {
            var records = _dbContext.Set<Cost>()
                .Include(x => x.CostType)
                .Include(x => x.Project)
                .Include(x => x.MonetaryAgent)
                .ToList();
            return records;
        }
    }
}