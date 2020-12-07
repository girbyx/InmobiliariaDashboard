using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.GainType
{
    [ApiController]
    [Route("api/[controller]")]
    public class GainTypeController : BaseCatalogController<GainTypeController, Models.GainType, GainTypeViewModel>
    {
        public GainTypeController(ILogger<GainTypeController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IBaseService<Models.GainType> baseService)
            : base(logger, mapper, dbContext, baseService)
        {
        }
    }
}