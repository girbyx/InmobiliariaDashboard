using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.LossType
{
    [ApiController]
    [Route("api/[controller]")]
    public class LossTypeController : BaseCatalogController<LossTypeController, Models.LossType, LossTypeViewModel>
    {
        public LossTypeController(ILogger<LossTypeController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IBaseService<Models.LossType> baseService)
            : base(logger, mapper, dbContext, baseService)
        {
        }
    }
}