using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Enterprise
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnterpriseDetailController : BaseDetailController<EnterpriseDetailController, Models.Enterprise, object
        , EnterpriseViewModel>
    {
        public EnterpriseDetailController(ILogger<EnterpriseDetailController> logger, IMapper mapper,
            IEnterpriseService baseService) : base(logger, mapper, baseService)
        {
        }
    }
}