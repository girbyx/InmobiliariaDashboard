using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.AutomapperResolvers
{
    public class ProjectSubTypesResolver : IValueResolver<object, object, IEnumerable<ProjectSubTypeViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IProjectSubTypeService _service;

        public ProjectSubTypesResolver(IMapper mapper, IProjectSubTypeService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<ProjectSubTypeViewModel> Resolve(object source, object destination,
            IEnumerable<ProjectSubTypeViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<ProjectSubTypeViewModel>);
        }
    }
}