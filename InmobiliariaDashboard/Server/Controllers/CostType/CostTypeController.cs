﻿using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.CostType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        CostTypeController : BaseCatalogController<CostTypeController, Models.CostType, object, CostTypeViewModel>
    {
        public CostTypeController(ILogger<CostTypeController> logger, IMapper mapper, ICostTypeService baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}