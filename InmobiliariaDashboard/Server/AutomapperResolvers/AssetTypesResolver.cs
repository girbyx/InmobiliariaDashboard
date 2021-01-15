using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.AutomapperResolvers
{
    public class AssetTypesResolver : IValueResolver<object, object, IEnumerable<AssetTypeViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAssetTypeService _service;

        public AssetTypesResolver(IMapper mapper, IAssetTypeService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<AssetTypeViewModel> Resolve(object source, object destination,
            IEnumerable<AssetTypeViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<AssetTypeViewModel>);
        }
    }
}