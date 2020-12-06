using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
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
        private readonly IBaseService<Models.CostType> _baseService;

        public CostTypeController(ILogger<CostTypeController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IBaseService<Models.CostType> baseService)
            : base(logger, mapper, dbContext, baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _baseService = baseService;
        }
    }
}