using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.GainType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        GainTypeController : BaseCatalogController<GainTypeController, Models.GainType, object, GainTypeViewModel>
    {
        public GainTypeController(ILogger<GainTypeController> logger, IMapper mapper,
            IBaseService<Models.GainType, object> baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}