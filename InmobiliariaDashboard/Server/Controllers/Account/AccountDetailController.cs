using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Account
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        AccountDetailController : BaseDetailController<AccountDetailController, Models.Account, AccountViewModel>
    {
        public AccountDetailController(ILogger<AccountDetailController> logger, IMapper mapper,
            IApplicationDbContext dbContext, IAccountService baseService) : base(logger, mapper,
            dbContext, baseService)
        {
        }
    }
}