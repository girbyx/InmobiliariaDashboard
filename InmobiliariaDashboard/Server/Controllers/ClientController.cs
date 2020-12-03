using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public ClientController(ILogger<ClientController> logger, IMapper mapper, IApplicationDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<ClientViewModel> Get()
        {
            var result = _dbContext
                .Set<Models.Client>()
                .Select(_mapper.Map<ClientViewModel>)
                .ToList();
            return result;
        }

        [HttpPost]
        public int Post(ClientViewModel dto)
        {
            var record = _mapper.Map<Models.Client>(dto);
            _dbContext.Add(record);
            return _dbContext.SaveChanges();
        }

        [HttpDelete]
        public int Delete(int id)
        {
            var record = _dbContext
                .Set<Models.Client>()
                .First(x => x.Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }

        [HttpPut]
        public int Put(ClientViewModel dto)
        {
            var record = _mapper.Map<Models.Client>(dto);
            _dbContext.Update(record);
            return _dbContext.SaveChanges();
        }
    }
}