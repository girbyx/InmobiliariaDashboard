using AutoMapper;
using InmobiliariaDashboard.Server.Data;
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

        public ClientDetailController(ILogger<ClientDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext) : base(logger, mapper, dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }
    }
}