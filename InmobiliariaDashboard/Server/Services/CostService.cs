using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CG.Web.MegaApiClient;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ICostService : IBaseService<Cost, object>
    {
    }

    public class CostService : BaseService<Cost, object>, ICostService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public CostService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
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

        public override int SaveAttachments(string[] files, int costId)
        {
            // open mega.nz connection
            MegaApiClient client = new MegaApiClient();
            string megaUsername = _configuration[Constants.UsernameConfigPath];
            string megaPassword = _configuration[Constants.PasswordConfigPath];
            client.Login(megaUsername, megaPassword);

            if (files != null && files.Any())
            {
                SaveToFileHosting(client, files, costId, Constants.CostFolderPath);
            }

            // close mega.nz connection
            client.Logout();

            return _dbContext.SaveChanges();
        }
    }
}