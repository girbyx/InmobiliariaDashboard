using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IReminderService : IBaseService<Reminder, object>
    {
        IEnumerable<Reminder> GetCurrent(int take = 3);
    }

    public class ReminderService : BaseService<Reminder, object>, IReminderService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ReminderService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public IEnumerable<Reminder> GetCurrent(int take = 3)
        {
            var records = _dbContext.Set<Reminder>()
                .Include(x => x.Enterprise)
                .OrderByDescending(x => x.NextOccurrence)
                .Take(take)
                .ToList();
            return records;
        }
    }
}