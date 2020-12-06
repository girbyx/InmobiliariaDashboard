using InmobiliariaDashboard.Server.Data;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IClientService : IBaseService<Models.Client>
    {
    }

    public class ClientService : BaseService<Models.Client>, IClientService
    {
        public ClientService(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}