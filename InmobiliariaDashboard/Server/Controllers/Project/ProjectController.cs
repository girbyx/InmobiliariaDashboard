using AutoMapper;
using InmobiliariaDashboard.Server.Data;
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

        public ProjectController(ILogger<ProjectController> logger, IMapper mapper, IApplicationDbContext dbContext)
            : base(logger, mapper, dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }
    }
}