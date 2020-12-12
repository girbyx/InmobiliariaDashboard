using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IEnterpriseService : IBaseService<Models.Enterprise, object>
    {
    }

    public class EnterpriseService : BaseService<Models.Enterprise, object>, IEnterpriseService
    {
        private readonly IApplicationDbContext _dbContext;

        public EnterpriseService(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<Models.Enterprise> GetAll()
        {
            var records = _dbContext.Set<Models.Enterprise>()
                .Include(x => x.Projects)
                .Include(x => x.MonetaryAgents)
                .ToList();
            return records;
        }
    }
}