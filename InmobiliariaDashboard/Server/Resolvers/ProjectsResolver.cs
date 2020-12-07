using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Resolvers
{
    public class ProjectsResolver : IValueResolver<object, object, IEnumerable<ProjectViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _service;

        public ProjectsResolver(IMapper mapper, IProjectService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<ProjectViewModel> Resolve(object source, object destination,
            IEnumerable<ProjectViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<ProjectViewModel>);
        }
    }
}