using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.AutomapperResolvers
{
    public class EnterprisesResolver : IValueResolver<object, object, IEnumerable<EnterpriseViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IEnterpriseService _service;

        public EnterprisesResolver(IMapper mapper, IEnterpriseService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<EnterpriseViewModel> Resolve(object source, object destination,
            IEnumerable<EnterpriseViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<EnterpriseViewModel>);
        }
    }
}