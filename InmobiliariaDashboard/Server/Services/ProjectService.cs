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
    public interface IProjectService : IBaseService<Project, ProjectHistory>
    {
    }

    public class ProjectService : BaseService<Project, ProjectHistory>, IProjectService
    {
        private readonly IApplicationDbContext _dbContext;

        public ProjectService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
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
            if (files != null && files.Any())
            {
                return SaveToFileHosting(files, projectId, Constants.ProjectFolderPath);
            }

            return 0;
        }
    }
}