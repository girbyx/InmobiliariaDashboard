using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.GainType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        GainTypeDetailController : BaseDetailController<GainTypeDetailController, Models.GainType, GainTypeViewModel>
    {
        private readonly ILogger<GainTypeDetailController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly IBaseService<Models.GainType> _baseService;

        public GainTypeDetailController(ILogger<GainTypeDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext, IBaseService<Models.GainType> baseService) : base(logger, mapper,
            dbContext, baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _baseService = baseService;
        }
    }
}