using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Cost
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostDetailController : BaseDetailController<CostDetailController, Models.Cost, CostViewModel>
    {
        public CostDetailController(ILogger<CostDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext, ICostService baseService) : base(logger, mapper, dbContext,
            baseService)
        {
        }
    }
}