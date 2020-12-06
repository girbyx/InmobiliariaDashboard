using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IProjectService : IBaseService<Project>
    {
    }

    public class ProjectService : BaseService<Project>, IProjectService
    {
        public ProjectService(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}