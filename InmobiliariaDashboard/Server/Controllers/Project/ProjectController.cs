using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Project
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : BaseCatalogController<ProjectController, Models.Project, ProjectViewModel>
    {
        public ProjectController(ILogger<ProjectController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IProjectService baseService)
            : base(logger, mapper, dbContext, baseService)
        {
        }
    }
}