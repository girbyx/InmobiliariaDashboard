using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IProjectService : IBaseService<Project>
    {
    }

    public class ProjectService : IProjectService
    {
        private readonly IApplicationDbContext _dbContext;

        public ProjectService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Project> GetAll()
        {
            var records = _dbContext.Set<Project>()
                .Include(x => x.Client)
                .ToList();
            return records;
        }
    }
}