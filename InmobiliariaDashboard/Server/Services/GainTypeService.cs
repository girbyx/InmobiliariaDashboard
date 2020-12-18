using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IGainTypeService : IBaseService<GainType, object>
    {
    }

    public class GainTypeService : BaseService<GainType, object>, IGainTypeService
    {
        private readonly IApplicationDbContext _dbContext;

        public GainTypeService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<GainType> GetAll()
        {
            var records = _dbContext.Set<GainType>()
                .Include(x => x.Gains)
                .ToList();
            return records;
        }
    }
}