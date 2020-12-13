﻿using AutoMapper;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Project
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : BaseCatalogController<ProjectController, Models.Project, ProjectHistory,
        ProjectViewModel>
    {
        private readonly IAttachmentService _attachmentService;

        public ProjectController(ILogger<ProjectController> logger, IMapper mapper, IProjectService baseService,
            IAttachmentService attachmentService) : base(
            logger, mapper, baseService, attachmentService)
        {
        }
    }
}