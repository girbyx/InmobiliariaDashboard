using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Asset
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        AssetDetailController : BaseDetailController<AssetDetailController, Entities.Asset, object, AssetViewModel>
    {
        public AssetDetailController(ILogger<AssetDetailController> logger, IMapper mapper,
            IBaseService<Entities.Asset, object> baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}