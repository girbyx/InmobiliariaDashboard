using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.MonetaryAgent
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        MonetaryAgentDetailController : BaseDetailController<MonetaryAgentDetailController, Models.MonetaryAgent, MonetaryAgentViewModel>
    {
        public MonetaryAgentDetailController(ILogger<MonetaryAgentDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext, IMonetaryAgentService baseService) : base(logger, mapper,
            dbContext, baseService)
        {
        }
    }
}