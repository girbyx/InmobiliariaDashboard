using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Gain
{
    [ApiController]
    [Route("api/[controller]")]
    public class GainDetailController : BaseDetailController<GainDetailController, Entities.Gain, object, GainViewModel>
    {
        public GainDetailController(ILogger<GainDetailController> logger, IMapper mapper, IGainService baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}