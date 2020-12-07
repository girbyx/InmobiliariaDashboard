using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IClientService : IBaseService<Models.Client>
    {
    }

    public class ClientService : IClientService
    {
        private readonly IApplicationDbContext _dbContext;

        public ClientService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.Client> GetAll()
        {
            var records = _dbContext.Set<Models.Client>()
                .Include(x => x.Projects)
                .Include(x => x.Accounts)
                .ToList();
            return records;
        }
    }
}