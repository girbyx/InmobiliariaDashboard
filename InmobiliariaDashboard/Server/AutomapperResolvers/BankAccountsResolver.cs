using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.AutomapperResolvers
{
    public class BankAccountsResolver : IValueResolver<object, object, IEnumerable<BankAccountViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IMonetaryAgentService _service;

        public BankAccountsResolver(IMapper mapper, IMonetaryAgentService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<BankAccountViewModel> Resolve(object source, object destination,
            IEnumerable<BankAccountViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<BankAccountViewModel>);
        }
    }
}