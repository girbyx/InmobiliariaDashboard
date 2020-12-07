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
    public class ClientController : BaseCatalogController<ClientController, Models.Client, ClientViewModel>
    {
        public ClientController(ILogger<ClientController> logger, IMapper mapper, IApplicationDbContext dbContext,
            IClientService baseService)
            : base(logger, mapper, dbContext, baseService)
        {
        }
    }
}