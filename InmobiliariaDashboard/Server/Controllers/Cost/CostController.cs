using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Cost
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostController : BaseCatalogController<CostController, Models.Cost, object, CostViewModel>
    {
        public CostController(ILogger<CostController> logger, IMapper mapper, ICostService baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}