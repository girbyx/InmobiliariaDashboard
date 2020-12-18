using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers
{
    public class BaseDetailController<TController, TEntity, THistory, TViewModel> : ControllerBase
        where TController : class
        where TEntity : class, new()
        where THistory : class
        where TViewModel : class
    {
        private readonly ILogger<TController> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseService<TEntity, THistory> _baseService;

        public BaseDetailController(ILogger<TController> logger, IMapper mapper, IBaseService<TEntity, THistory> baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _baseService = baseService;
        }

        [HttpGet]
        public TViewModel Get(int id)
        {
            var result = _mapper.Map<TViewModel>(_baseService.Get(id));
            return result;
        }

        [HttpGet]
        [Route("GetEmpty")]
        public TViewModel GetEmpty()
        {
            var result = _mapper.Map<TViewModel>(new TEntity());
            return result;
        }

        [HttpGet]
        [Route("GetHistory")]
        public IEnumerable<TViewModel> GetHistory()
        {
            var result = _baseService.GetHistory()
                .Select(_mapper.Map<TViewModel>);
            return result;
        }
    }
}