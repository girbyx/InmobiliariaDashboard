using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Resolvers
{
    public class ClientsResolver : IValueResolver<Project, ProjectViewModel, IEnumerable<ClientViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IClientService _clientService;

        public ClientsResolver(IMapper mapper, IClientService clientService)
        {
            _mapper = mapper;
            _clientService = clientService;
        }

        public IEnumerable<ClientViewModel> Resolve(Project source, ProjectViewModel destination,
            IEnumerable<ClientViewModel> destMember,
            ResolutionContext context)
        {
            return _clientService.GetAll().Select(_mapper.Map<ClientViewModel>);
        }
    }
}