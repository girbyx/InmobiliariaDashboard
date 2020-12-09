using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IBalanceService
    {
        IEnumerable<BalanceViewModel> GetAll();
    }

    public class BalanceService : IBalanceService
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public BalanceService(IMapper mapper, IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public IEnumerable<BalanceViewModel> GetAll()
        {
            var records = _dbContext.Set<Enterprise>()
                .Include(x => x.Projects).ThenInclude(x => x.Costs)
                .Include(x => x.Projects).ThenInclude(x => x.Gains)
                .Include(x => x.Projects).ThenInclude(x => x.Losses)
                .ToList().Select(_mapper.Map<BalanceViewModel>);
            return records;
        }
    }
}