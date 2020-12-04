using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.CostType
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostTypeController : BaseCatalogController<CostTypeController, Models.CostType, CostTypeViewModel>
    {
        private readonly ILogger<CostTypeController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public CostTypeController(ILogger<CostTypeController> logger, IMapper mapper, IApplicationDbContext dbContext)
            : base(logger, mapper, dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }
    }
}