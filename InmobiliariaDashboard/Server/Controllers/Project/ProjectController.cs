using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InmobiliariaDashboard.Server.Entities;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Project
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : BaseCatalogController<ProjectController, Entities.Project, ProjectHistory,
        ProjectViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _baseService;

        public ProjectController(ILogger<ProjectController> logger, IMapper mapper, IProjectService baseService) : base(
            logger, mapper, baseService)
        {
            _mapper = mapper;
            _baseService = baseService;
        }

        [HttpPost]
        [Route("SendProjectInformation")]
        public async Task<bool> SendProjectInformation(SendProjectInformationViewModel dto)
        {
            var result = await _baseService.EmailProjectInformation(dto);
            return result;
        }

        [HttpGet]
        [Route("ByEnterprise")]
        public IEnumerable<ProjectViewModel> ByEnterprise(int id)
        {
            var result = _baseService.GetByEnterprise(id).Select(_mapper.Map<ProjectViewModel>);
            return result;
        }
    }
}