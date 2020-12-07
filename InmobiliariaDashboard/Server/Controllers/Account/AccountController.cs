using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;
        private readonly IAccountService _baseService;

        public AccountController(ILogger<AccountController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IAccountService baseService)
            : base(logger, mapper, dbContext, baseService)
        {
            _mapper = mapper;
            _baseService = baseService;
        }

        [Route("ByProject")]
        public IEnumerable<AccountViewModel> ByProject(int id)
        {
            var result = _baseService.GetByProject(id).Select(_mapper.Map<AccountViewModel>);
            return result;
        }
    }
}