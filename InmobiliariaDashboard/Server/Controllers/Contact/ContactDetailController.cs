using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Contact
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        ContactDetailController : BaseDetailController<ContactDetailController, Models.Contact, object,
            ContactViewModel>
    {
        public ContactDetailController(ILogger<ContactDetailController> logger, IMapper mapper,
            IContactService baseService) : base(logger, mapper, baseService)
        {
        }
    }
}