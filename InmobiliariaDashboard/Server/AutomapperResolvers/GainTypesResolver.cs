using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.AutomapperResolvers
{
    public class GainTypesResolver : IValueResolver<object, object, IEnumerable<GainTypeViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGainTypeService _service;

        public GainTypesResolver(IMapper mapper, IGainTypeService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<GainTypeViewModel> Resolve(object source, object destination,
            IEnumerable<GainTypeViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<GainTypeViewModel>);
        }
    }
}