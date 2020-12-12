using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Asset
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : BaseCatalogController<AssetController, Models.Asset, AssetViewModel>
    {
        public AssetController(ILogger<AssetController> logger, IMapper mapper, IBaseService<Models.Asset> baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}