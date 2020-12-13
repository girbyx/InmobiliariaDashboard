using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Asset
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : BaseCatalogController<AssetController, Models.Asset, object, AssetViewModel>
    {
        public AssetController(ILogger<AssetController> logger, IMapper mapper,
            IBaseService<Models.Asset, object> baseService, IAttachmentService attachmentService)
            : base(logger, mapper, baseService, attachmentService)
        {
        }
    }
}