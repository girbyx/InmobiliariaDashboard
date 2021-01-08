using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.MonetaryAgent
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonetaryAgentController : BaseCatalogController<MonetaryAgentController, Models.MonetaryAgent, object,
        MonetaryAgentViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IMonetaryAgentService _baseService;

        public MonetaryAgentController(ILogger<MonetaryAgentController> logger, IMapper mapper,
            IMonetaryAgentService baseService)
            : base(logger, mapper, baseService)
        {
            _mapper = mapper;
            _baseService = baseService;
        }

        [HttpGet]
        [Route("ByEnterprise")]
        public IEnumerable<MonetaryAgentViewModel> ByEnterprise(int id)
        {
            var result = _baseService.GetByEnterprise(id).Select(_mapper.Map<MonetaryAgentViewModel>);
            return result;
        }

        [HttpGet]
        [Route("ByProject")]
        public IEnumerable<MonetaryAgentViewModel> ByProject(int id)
        {
            var result = _baseService.GetByProject(id).Select(_mapper.Map<MonetaryAgentViewModel>);
            return result;
        }
    }
}