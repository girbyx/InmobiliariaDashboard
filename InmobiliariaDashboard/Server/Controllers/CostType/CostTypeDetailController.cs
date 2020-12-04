using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.CostType
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostTypeDetailController : BaseDetailController<CostTypeDetailController, Models.CostType, CostTypeViewModel>
    {
        private readonly ILogger<CostTypeDetailController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public CostTypeDetailController(ILogger<CostTypeDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext) : base(logger, mapper, dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }
    }
}