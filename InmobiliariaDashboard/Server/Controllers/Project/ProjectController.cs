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
        private readonly ILogger<ProjectController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly IBaseService<Models.Project> _baseService;

        public ProjectController(ILogger<ProjectController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IBaseService<Models.Project> baseService)
            : base(logger, mapper, dbContext, baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _baseService = baseService;
        }
    }
}