using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.AutomapperResolvers
{
    public class LossTypesResolver : IValueResolver<object, object, IEnumerable<LossTypeViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ILossTypeService _service;

        public LossTypesResolver(IMapper mapper, ILossTypeService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<LossTypeViewModel> Resolve(object source, object destination,
            IEnumerable<LossTypeViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<LossTypeViewModel>);
        }
    }
}