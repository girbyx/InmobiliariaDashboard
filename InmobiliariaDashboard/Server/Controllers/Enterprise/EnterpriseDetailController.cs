using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Client
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnterpriseDetailController : BaseDetailController<EnterpriseDetailController, Models.Enterprise, EnterpriseViewModel>
    {
        public EnterpriseDetailController(ILogger<EnterpriseDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext, IBaseService<Models.Enterprise> baseService) : base(logger, mapper, dbContext,
            baseService)
        {
        }
    }
}