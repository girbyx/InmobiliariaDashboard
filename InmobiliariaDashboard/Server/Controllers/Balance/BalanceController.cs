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

        public IEnumerable<BalanceViewModel> Get()
        {
            var records = _baseService.GetAll();
            var result = records.Select(_mapper.Map<BalanceViewModel>);
            return result;
        }
    }
}