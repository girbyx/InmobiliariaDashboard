using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.AssetType
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetTypeController : BaseCatalogController<AssetTypeController, Models.AssetType, AssetTypeViewModel>
    {
        public AssetTypeController(ILogger<AssetTypeController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IAssetTypeService baseService)
            : base(logger, mapper, dbContext, baseService)
        {
        }
    }
}