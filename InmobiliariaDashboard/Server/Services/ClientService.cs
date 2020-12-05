using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IClientService : IBaseService<ClientViewModel>
    {
    }

    public class ClientService : BaseService<Models.Client, ClientViewModel>, IClientService
    {
        public ClientService(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}