using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.CostType
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostTypeController : BaseCatalogController<CostTypeController, Models.CostType, CostTypeViewModel>
    {
        public CostTypeController(ILogger<CostTypeController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IBaseService<Models.CostType> baseService)
            : base(logger, mapper, dbContext, baseService)
        {
        }
    }
}