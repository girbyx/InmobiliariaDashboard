using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.AutomapperResolvers
{
    public class PeoplesResolver : IValueResolver<object, object, IEnumerable<PeopleViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IEnterpriseService _service;

        public PeoplesResolver(IMapper mapper, IEnterpriseService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<PeopleViewModel> Resolve(object source, object destination,
            IEnumerable<PeopleViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<PeopleViewModel>);
        }
    }
}