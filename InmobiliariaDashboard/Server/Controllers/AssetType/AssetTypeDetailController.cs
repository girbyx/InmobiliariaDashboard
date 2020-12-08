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
    public class
        AssetTypeDetailController : BaseDetailController<AssetTypeDetailController, Models.AssetType, AssetTypeViewModel>
    {
        public AssetTypeDetailController(ILogger<AssetTypeDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext, IAssetTypeService baseService) : base(logger, mapper,
            dbContext, baseService)
        {
        }
    }
}