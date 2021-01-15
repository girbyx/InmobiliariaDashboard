﻿using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.GainType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        GainTypeDetailController : BaseDetailController<GainTypeDetailController, Entities.GainType, object,
            GainTypeViewModel>
    {
        public GainTypeDetailController(ILogger<GainTypeDetailController> logger, IMapper mapper,
            IBaseService<Entities.GainType, object> baseService) : base(logger, mapper, baseService)
        {
        }
    }
}