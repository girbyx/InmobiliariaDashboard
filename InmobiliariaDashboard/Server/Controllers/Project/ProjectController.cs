using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IProjectService _baseService;

        public ProjectController(ILogger<ProjectController> logger, IMapper mapper, IProjectService baseService) : base(
            logger, mapper, baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        [Route("SendProjectInformation")]
        public async Task<bool> SendProjectInformation(SendProjectInformationViewModel dto)
        {
            var result = await _baseService.EmailProjectInformation(dto);
            return result;
        }
    }
}