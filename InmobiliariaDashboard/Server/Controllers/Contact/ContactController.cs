using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Contact
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : BaseCatalogController<ContactController, Models.Contact, object,
        ContactViewModel>
    {
        public ContactController(ILogger<ContactController> logger, IMapper mapper, IContactService baseService,
            IAttachmentService attachmentService)
            : base(logger, mapper, baseService, attachmentService)
        {
        }
    }
}