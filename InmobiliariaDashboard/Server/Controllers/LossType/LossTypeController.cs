using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.LossType
{
    [ApiController]
    [Route("api/[controller]")]
    public class LossTypeController : BaseCatalogController<LossTypeController, Models.LossType, LossTypeViewModel>
    {
        private readonly ILogger<LossTypeController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly IBaseService<Models.LossType> _baseService;

        public LossTypeController(ILogger<LossTypeController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IBaseService<Models.LossType> baseService)
            : base(logger, mapper, dbContext, baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _baseService = baseService;
        }
    }
}