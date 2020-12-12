using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.ProjectSubType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        ProjectSubTypeDetailController : BaseDetailController<ProjectSubTypeDetailController, Models.ProjectSubType, object,
            ProjectSubTypeViewModel>
    {
        public ProjectSubTypeDetailController(ILogger<ProjectSubTypeDetailController> logger, IMapper mapper,
            IProjectSubTypeService baseService) : base(logger, mapper, baseService)
        {
        }
    }
}