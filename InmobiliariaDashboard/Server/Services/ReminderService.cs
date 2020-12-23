﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IReminderService : IBaseService<Reminder, object>
    {
        IEnumerable<Reminder> GetCurrent();
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

        public IEnumerable<Reminder> GetCurrent()
        {
            var daysToOccurrence = Convert.ToInt32(_configuration[Constants.DaysToOccurrence]);
            var records = _dbContext.Set<Reminder>()
                .ToList()
                .OrderByDescending(x => x.NextOccurrence)
                .Where(x => x.DaysForNextOccurrence <= daysToOccurrence);
            return records;
        }
    }
}