using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IAccountService : IBaseService<Account>
    {
        IEnumerable<Account> GetByProject(int id);
    }

    public class AccountService : IAccountService
    {
        private readonly IApplicationDbContext _dbContext;

        public AccountService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Account> GetAll()
        {
            var records = _dbContext.Set<Account>()
                .Include(x => x.Client)
                .ToList();
            return records;
        }

        public IEnumerable<Account> GetAllForResolver()
        {
            var records = _dbContext.Set<Account>().ToList();
            return records;
        }

        public IEnumerable<Account> GetByProject(int id)
        {
            var records = _dbContext.Set<Account>()
                .Where(x => x.Client.Projects.Any(y => y.Id == id))
                .ToList();
            return records;
        }
    }
}