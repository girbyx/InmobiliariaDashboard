using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.MonetaryAgent
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        MonetaryAgentDetailController : BaseDetailController<MonetaryAgentDetailController, Entities.MonetaryAgent, object
            , MonetaryAgentViewModel>
    {
        public MonetaryAgentDetailController(ILogger<MonetaryAgentDetailController> logger, IMapper mapper,
            IMonetaryAgentService baseService) : base(logger, mapper, baseService)
        {
        }
    }
}