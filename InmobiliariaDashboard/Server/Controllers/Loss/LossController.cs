using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Loss
{
    [ApiController]
    [Route("api/[controller]")]
    public class LossController : BaseCatalogController<LossController, Models.Loss, object, LossViewModel>
    {
        public LossController(ILogger<LossController> logger, IMapper mapper, ILossService baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}