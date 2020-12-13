﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ICostTypeService : IBaseService<CostType, object>
    {
    }

    public class CostTypeService : BaseService<CostType, object>, ICostTypeService
    {
        private readonly IApplicationDbContext _dbContext;

        public CostTypeService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<CostType> GetAll()
        {
            var records = _dbContext.Set<CostType>()
                .Include(x => x.Costs)
                .ToList();
            return records;
        }
    }
}