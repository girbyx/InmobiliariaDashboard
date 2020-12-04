using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers
{
    public class BaseCatalogController<TController, TEntity, TViewModel> : ControllerBase
        where TController : class
        where TEntity : class
        where TViewModel : class
    {
        private readonly ILogger<TController> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public BaseCatalogController(ILogger<TController> logger, IMapper mapper, IApplicationDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<TViewModel> Get()
        {
            var result = _dbContext
                .Set<TEntity>()
                .Select(_mapper.Map<TViewModel>)
                .ToList();
            return result;
        }

        [HttpPost]
        public int Post(TViewModel dto)
        {
            var record = _mapper.Map<TEntity>(dto);
            _dbContext.Add(record);
            return _dbContext.SaveChanges();
        }

        [HttpDelete]
        public int Delete(int id)
        {
            var record = _dbContext
                .Set<TEntity>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }

        [HttpPut]
        public int Put(TViewModel dto)
        {
            var record = _mapper.Map<TEntity>(dto);
            _dbContext.Update(record);
            return _dbContext.SaveChanges();
        }
    }
}