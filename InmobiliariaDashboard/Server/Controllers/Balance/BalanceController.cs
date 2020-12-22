using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Balance
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly ILogger<BalanceController> _logger;
        private readonly IMapper _mapper;
        private readonly IBalanceService _baseService;

        public BalanceController(ILogger<BalanceController> logger, IMapper mapper, IBalanceService baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _baseService = baseService;
        }

        [HttpGet]
        [Route("GetEnterprise")]
        public IEnumerable<EnterpriseBalanceViewModel> GetEnterprise()
        {
            var records = _baseService.GetEnterpriseBalances();
            var result = records.Select(_mapper.Map<EnterpriseBalanceViewModel>);
            return result;
        }

        [HttpGet]
        [Route("GetMonetaryAgent")]
        public IEnumerable<MonetaryAgentBalanceViewModel> GetMonetaryAgent()
        {
            var records = _baseService.GetMonetaryAgentBalances();
            var result = records.Select(_mapper.Map<MonetaryAgentBalanceViewModel>);
            return result;
        }
    }
}