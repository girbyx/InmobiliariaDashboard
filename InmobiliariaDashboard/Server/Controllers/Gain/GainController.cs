using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Gain
{
    [ApiController]
    [Route("api/[controller]")]
    public class GainController : BaseCatalogController<GainController, Models.Gain, object, GainViewModel>
    {
        public GainController(ILogger<GainController> logger, IMapper mapper, IGainService baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}