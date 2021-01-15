using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.AssetType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        AssetTypeController : BaseCatalogController<AssetTypeController, Entities.AssetType, object, AssetTypeViewModel>
    {
        public AssetTypeController(ILogger<AssetTypeController> logger, IMapper mapper, IAssetTypeService baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}