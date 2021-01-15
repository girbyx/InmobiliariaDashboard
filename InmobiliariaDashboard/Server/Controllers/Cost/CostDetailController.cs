using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Cost
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostDetailController : BaseDetailController<CostDetailController, Entities.Cost, object, CostViewModel>
    {
        public CostDetailController(ILogger<CostDetailController> logger, IMapper mapper, ICostService baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}