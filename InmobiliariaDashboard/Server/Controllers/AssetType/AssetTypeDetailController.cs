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
        AssetTypeDetailController : BaseDetailController<AssetTypeDetailController, Models.AssetType, object,
            AssetTypeViewModel>
    {
        public AssetTypeDetailController(ILogger<AssetTypeDetailController> logger, IMapper mapper,
            IAssetTypeService baseService) : base(logger, mapper, baseService)
        {
        }
    }
}