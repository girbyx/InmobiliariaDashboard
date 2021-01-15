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
        ReminderDetailController : BaseDetailController<ReminderDetailController, Entities.Reminder, object,
            ReminderViewModel>
    {
        public ReminderDetailController(ILogger<ReminderDetailController> logger, IMapper mapper,
            IBaseService<Entities.Reminder, object> baseService) : base(logger, mapper, baseService)
        {
        }
    }
}