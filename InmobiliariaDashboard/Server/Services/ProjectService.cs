using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IProjectService : IBaseService<Project, ProjectHistory>
    {
    }

    public class ProjectService : BaseService<Project, ProjectHistory>, IProjectService
    {
        private readonly IApplicationDbContext _dbContext;

        public ProjectService(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<Project> GetAll()
        {
            var records = _dbContext.Set<Project>()
                .Include(x => x.Enterprise)
                .ToList();
            return records;
        }
    }
}