using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Resolvers
{
    public class AccountsResolver : IValueResolver<object, object, IEnumerable<AccountViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _service;

        public AccountsResolver(IMapper mapper, IAccountService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IEnumerable<AccountViewModel> Resolve(object source, object destination,
            IEnumerable<AccountViewModel> destMember,
            ResolutionContext context)
        {
            return _service.GetAllForResolver().Select(_mapper.Map<AccountViewModel>);
        }
    }
}