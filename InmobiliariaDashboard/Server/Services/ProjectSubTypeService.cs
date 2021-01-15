using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IProjectSubTypeService : IBaseService<ProjectSubType, object>
    {
    }

    public class ProjectSubTypeService : BaseService<ProjectSubType, object>, IProjectSubTypeService
    {
        public ProjectSubTypeService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) :
            base(dbContext, mapper, configuration)
        {
        }
    }
}