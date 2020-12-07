using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IAccountService : IBaseService<Account>
    {
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
    }
}