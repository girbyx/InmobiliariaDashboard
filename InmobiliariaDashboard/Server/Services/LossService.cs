using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ILossService : IBaseService<Loss, object>
    {
    }

    public class LossService : BaseService<Loss, object>, ILossService
    {
        private readonly IApplicationDbContext _dbContext;

        public LossService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<Loss> GetAll()
        {
            var records = _dbContext.Set<Loss>()
                .Include(x => x.LossType)
                .Include(x => x.Project)
                .Include(x => x.MonetaryAgent)
                .ToList();
            return records;
        }

        public override int SaveAttachments(string[] files, int costId)
        {
            if (files != null && files.Any())
            {
                return SaveToFileHosting(files, costId, Constants.CostFolderPath);
            }

            return 0;
        }
    }
}