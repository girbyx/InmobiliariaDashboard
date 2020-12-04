using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.LossType
{
    [ApiController]
    [Route("api/[controller]")]
    public class LossTypeDetailController : BaseDetailController<LossTypeDetailController, Models.LossType, LossTypeViewModel>
    {
        private readonly ILogger<LossTypeDetailController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public LossTypeDetailController(ILogger<LossTypeDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext) : base(logger, mapper, dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }
    }
}