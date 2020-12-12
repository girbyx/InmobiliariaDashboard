using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers
{
    public class BaseCatalogController<TController, TEntity, THistory, TViewModel> : ControllerBase
        where TController : class
        where TEntity : class
        where THistory : class
        where TViewModel : class
    {
        private readonly ILogger<TController> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseService<TEntity, THistory> _baseService;

        public BaseCatalogController(ILogger<TController> logger, IMapper mapper, IBaseService<TEntity, THistory> baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _baseService = baseService;
        }

        [HttpGet]
        public IEnumerable<TViewModel> Get()
        {
            var result = _baseService.GetAll()
                .Select(_mapper.Map<TViewModel>);
            return result;
        }

        [HttpPost]
        public int Post(TViewModel dto)
        {
            return _baseService.Save(_mapper.Map<TEntity>(dto));
        }

        [HttpDelete]
        public int Delete(int id)
        {
            return _baseService.Delete(id);
        }

        [HttpDelete]
        [Route("Archive")]
        public int Archive(int id)
        {
            return _baseService.Archive(id);
        }

        [HttpPut]
        public int Put(TViewModel dto)
        {
            return _baseService.Save(_mapper.Map<TEntity>(dto));
        }
    }
}