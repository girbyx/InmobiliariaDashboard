using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Server.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IMonetaryAgentService : IBaseService<MonetaryAgent>
    {
        IEnumerable<MonetaryAgent> GetByProject(int id);
    }

    public class MonetaryAgentService : IMonetaryAgentService
    {
        private readonly IApplicationDbContext _dbContext;

        public MonetaryAgentService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MonetaryAgent> GetAll()
        {
            var records = _dbContext.Set<MonetaryAgent>()
                .Include(x => x.Enterprise)
                .ToList();
            return records;
        }

        public IEnumerable<MonetaryAgent> GetAllForResolver()
        {
            var records = _dbContext.Set<MonetaryAgent>().ToList();
            return records;
        }

        public IEnumerable<MonetaryAgent> GetByProject(int id)
        {
            var records = _dbContext.Set<MonetaryAgent>()
                .Where(x => x.Enterprise.Projects.Any(y => y.Id == id))
                .ToList();
            return records;
        }

        public int Save(MonetaryAgent entity)
        {
            if ((entity as IIdentityFields).Id == 0)
                _dbContext.Add(entity);
            else
                _dbContext.Update(entity);

            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var record = _dbContext
                .Set<MonetaryAgent>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }
    }
}