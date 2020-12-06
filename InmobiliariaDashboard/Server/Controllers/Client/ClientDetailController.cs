using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Client
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientDetailController : BaseDetailController<ClientDetailController, Models.Client, ClientViewModel>
    {
        private readonly ILogger<ClientDetailController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly IBaseService<Models.Client> _baseService;

        public ClientDetailController(ILogger<ClientDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext, IBaseService<Models.Client> baseService) : base(logger, mapper, dbContext,
            baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _baseService = baseService;
        }
    }
}