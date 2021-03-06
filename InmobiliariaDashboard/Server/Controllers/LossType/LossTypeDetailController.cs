﻿using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.LossType
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        LossTypeDetailController : BaseDetailController<LossTypeDetailController, Models.LossType, object,
            LossTypeViewModel>
    {
        public LossTypeDetailController(ILogger<LossTypeDetailController> logger, IMapper mapper,
            IBaseService<Models.LossType, object> baseService) : base(logger, mapper, baseService)
        {
        }
    }
}