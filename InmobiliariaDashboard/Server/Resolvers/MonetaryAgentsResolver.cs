using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Resolvers
{
    public class MonetaryAgentsResolver : IValueResolver<object, object, IEnumerable<MonetaryAgentViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IMonetaryAgentService _service;

        public MonetaryAgentsResolver(IMapper mapper, IMonetaryAgentService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<MonetaryAgentViewModel> Resolve(object source, object destination,
            IEnumerable<MonetaryAgentViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<MonetaryAgentViewModel>);
        }
    }
}