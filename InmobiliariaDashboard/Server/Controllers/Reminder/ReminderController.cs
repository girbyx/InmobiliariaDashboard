using System.Collections.Generic;
using System.Linq;
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
        ReminderController : BaseCatalogController<ReminderController, Entities.Reminder, object, ReminderViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IReminderService _baseService;

        public ReminderController(ILogger<ReminderController> logger, IMapper mapper,
            IReminderService baseService)
            : base(logger, mapper, baseService)
        {
            _mapper = mapper;
            _baseService = baseService;
        }

        [HttpGet]
        [Route("GetCurrent")]
        public IEnumerable<ReminderViewModel> GetCurrent()
        {
            var result = _baseService.GetCurrent()
                .Select(_mapper.Map<ReminderViewModel>);
            return result;
        }
    }
}