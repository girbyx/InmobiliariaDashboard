using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ILossTypeService : IBaseService<LossType, object>
    {
    }

    public class LossTypeService : BaseService<LossType, object>, ILossTypeService
    {
        private readonly IApplicationDbContext _dbContext;

        public LossTypeService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<LossType> GetAll()
        {
            var records = _dbContext.Set<LossType>()
                .Include(x => x.Losses)
                .ToList();
            return records;
        }
    }
}