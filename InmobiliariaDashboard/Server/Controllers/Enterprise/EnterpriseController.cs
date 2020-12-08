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
    public class EnterpriseController : BaseCatalogController<EnterpriseController, Models.Enterprise, EnterpriseViewModel>
    {
        public EnterpriseController(ILogger<EnterpriseController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IEnterpriseService baseService)
            : base(logger, mapper, dbContext, baseService)
        {
        }
    }
}