using System.Collections.Generic;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Balance
{
    public class BalanceController : ControllerBase
    {
        private readonly ILogger<BalanceController> _logger;
        private readonly IBalanceService _baseService;

        public BalanceController(ILogger<BalanceController> logger, IBalanceService baseService)
        {
            _logger = logger;
            _baseService = baseService;
        }

        public IEnumerable<BalanceViewModel> Get()
        {
            var result = _baseService.GetAll();
            return result;
        }
    }
}
