using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers
{
    public class BaseDetailController<TController, TEntity, TViewModel> : ControllerBase
        where TController : class
        where TEntity : class, new()
        where TViewModel : class
    {
        private readonly ILogger<TController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public BaseDetailController(ILogger<TController> logger, IMapper mapper, IApplicationDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public TViewModel Get(int id)
        {
            var result = _dbContext
                .Set<TEntity>()
                .Where(x => (x as IIdentityFields).Id == id)
                .AsEnumerable()
                .Select(_mapper.Map<TViewModel>)
                .First();
            return result;
        }

        [HttpGet]
        [Route("GetEmpty")]
        public TViewModel GetEmpty()
        {
            var result = _mapper.Map<TViewModel>(new TEntity());
            return result;
        }
    }
}