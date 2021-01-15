using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.AutomapperResolvers
{
    public class CostTypesResolver : IValueResolver<object, object, IEnumerable<CostTypeViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICostTypeService _service;

        public CostTypesResolver(IMapper mapper, ICostTypeService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<CostTypeViewModel> Resolve(object source, object destination,
            IEnumerable<CostTypeViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<CostTypeViewModel>);
        }
    }
}