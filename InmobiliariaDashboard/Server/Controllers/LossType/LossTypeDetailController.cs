using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.LossType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        LossTypeDetailController : BaseDetailController<LossTypeDetailController, Models.LossType, LossTypeViewModel>
    {
        public LossTypeDetailController(ILogger<LossTypeDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext, IBaseService<Models.LossType> baseService) : base(logger, mapper,
            dbContext, baseService)
        {
        }
    }
}