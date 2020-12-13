using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.ProjectSubType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        ProjectSubTypeController : BaseCatalogController<ProjectSubTypeController, Models.ProjectSubType, object,
            ProjectSubTypeViewModel>
    {
        public ProjectSubTypeController(ILogger<ProjectSubTypeController> logger, IMapper mapper,
            IProjectSubTypeService baseService, IAttachmentService attachmentService)
            : base(logger, mapper, baseService, attachmentService)
        {
        }
    }
}