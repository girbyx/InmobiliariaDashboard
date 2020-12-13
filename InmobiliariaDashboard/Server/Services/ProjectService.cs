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
    public interface IProjectService : IBaseService<Project, ProjectHistory>
    {
    }

    public class ProjectService : BaseService<Project, ProjectHistory>, IProjectService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ProjectService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public override IEnumerable<Project> GetAll()
        {
            var records = _dbContext.Set<Project>()
                .Include(x => x.Enterprise)
                .Include(x => x.Attachments)
                .ToList();
            return records;
        }

        public override Project Get(int id)
        {
            var records = _dbContext.Set<Project>()
                .Include(x => x.Attachments)
                .Single(x => x.Id == id);
            return records;
        }

        public override int SaveAttachments(string[] files, int projectId)
        {
            // open mega.nz connection
            MegaApiClient client = new MegaApiClient();
            string megaUsername = _configuration[Constants.UsernameConfigPath];
            string megaPassword = _configuration[Constants.PasswordConfigPath];
            client.Login(megaUsername, megaPassword);

            if (files != null && files.Any())
            {
                SaveToFileHosting(client, files, projectId, Constants.ProjectFolderPath);
            }

            // close mega.nz connection
            client.Logout();

            return _dbContext.SaveChanges();
        }
    }
}