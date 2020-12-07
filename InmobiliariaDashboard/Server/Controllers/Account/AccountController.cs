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
    public class AccountController : BaseCatalogController<AccountController, Models.Account, AccountViewModel>
    {
        public AccountController(ILogger<AccountController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IAccountService baseService)
            : base(logger, mapper, dbContext, baseService)
        {
        }
    }
}