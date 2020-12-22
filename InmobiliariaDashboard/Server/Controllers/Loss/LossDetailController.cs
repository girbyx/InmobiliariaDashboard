using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Loss
{
    [ApiController]
    [Route("api/[controller]")]
    public class LossDetailController : BaseDetailController<LossDetailController, Models.Loss, object, LossViewModel>
    {
        public LossDetailController(ILogger<LossDetailController> logger, IMapper mapper, ILossService baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}