﻿using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IBalanceService
    {
        IEnumerable<Enterprise> GetEnterpriseBalances();
        IEnumerable<MonetaryAgent> GetMonetaryAgentBalances();
    }

    public class BalanceService : IBalanceService
    {
        private readonly IApplicationDbContext _dbContext;

        public BalanceService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Enterprise> GetEnterpriseBalances()
        {
            var records = _dbContext.Set<Enterprise>()
                .Include(x => x.Assets)
                .Include(x => x.Costs)
                .Include(x => x.Gains)
                .Include(x => x.Losses)
                .Include(x => x.Projects).ThenInclude(x => x.Costs)
                .Include(x => x.Projects).ThenInclude(x => x.Gains)
                .Include(x => x.Projects).ThenInclude(x => x.Losses)
                .ToList();
            return records;
        }

        public IEnumerable<MonetaryAgent> GetMonetaryAgentBalances()
        {
            var records = _dbContext.Set<MonetaryAgent>()
                .Include(x => x.Costs)
                .Include(x => x.Gains)
                .Include(x => x.Losses)
                .ToList();
            return records;
        }
    }
}