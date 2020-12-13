using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Enterprise
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnterpriseController : BaseCatalogController<EnterpriseController, Models.Enterprise, object,
        EnterpriseViewModel>
    {
        public EnterpriseController(ILogger<EnterpriseController> logger, IMapper mapper,
            IEnterpriseService baseService, IAttachmentService attachmentService)
            : base(logger, mapper, baseService, attachmentService)
        {
        }
    }
}