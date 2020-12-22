using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Reminder
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        ReminderController : BaseCatalogController<ReminderController, Models.Reminder, object, ReminderViewModel>
    {
        public ReminderController(ILogger<ReminderController> logger, IMapper mapper,
            IBaseService<Models.Reminder, object> baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}