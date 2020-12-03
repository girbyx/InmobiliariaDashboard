using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientDetailController : ControllerBase
    {
        private readonly ILogger<ClientDetailController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public ClientDetailController(ILogger<ClientDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ClientViewModel Get(int id)
        {
            var result = _dbContext
                .Set<Models.Client>()
                .Where(x => x.Id == id)
                .AsEnumerable()
                .Select(_mapper.Map<ClientViewModel>)
                .First();
            return result;
        }
    }
}