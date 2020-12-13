using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IProjectSubTypeService : IBaseService<ProjectSubType, object>
    {
    }

    public class ProjectSubTypeService : BaseService<ProjectSubType, object>, IProjectSubTypeService
    {
        private readonly IApplicationDbContext _dbContext;

        public ProjectSubTypeService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) :
            base(dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<ProjectSubType> GetAll()
        {
            var records = _dbContext.Set<ProjectSubType>()
                .Include(x => x.Projects)
                .ToList();
            return records;
        }
    }
}