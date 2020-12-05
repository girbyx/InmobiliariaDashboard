using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Project
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectDetailController : BaseDetailController<ProjectDetailController, Models.Project, ProjectViewModel>
    {
        private readonly ILogger<ProjectDetailController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public ProjectDetailController(ILogger<ProjectDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext) : base(logger, mapper, dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }
    }
}