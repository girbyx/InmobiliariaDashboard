using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Attachment
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        AttachmentDetailController : BaseDetailController<AttachmentDetailController, Models.Attachment, object,
            AttachmentViewModel>
    {
        public AttachmentDetailController(ILogger<AttachmentDetailController> logger, IMapper mapper,
            IAttachmentService baseService) : base(logger, mapper, baseService)
        {
        }
    }
}