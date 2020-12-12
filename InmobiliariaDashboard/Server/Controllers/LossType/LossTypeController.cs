using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.LossType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        LossTypeController : BaseCatalogController<LossTypeController, Models.LossType, object, LossTypeViewModel>
    {
        public LossTypeController(ILogger<LossTypeController> logger, IMapper mapper,
            IBaseService<Models.LossType, object> baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}