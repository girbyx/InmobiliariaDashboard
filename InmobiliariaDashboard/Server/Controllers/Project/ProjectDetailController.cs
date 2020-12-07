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
    public class
        ProjectDetailController : BaseDetailController<ProjectDetailController, Models.Project, ProjectViewModel>
    {
        public ProjectDetailController(ILogger<ProjectDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext, IBaseService<Models.Project> baseService) : base(logger, mapper, dbContext,
            baseService)
        {
        }
    }
}