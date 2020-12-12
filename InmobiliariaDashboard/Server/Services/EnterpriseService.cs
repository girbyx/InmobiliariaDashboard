using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IEnterpriseService : IBaseService<Models.Enterprise>
    {
    }

    public class EnterpriseService : IEnterpriseService
    {
        private readonly IApplicationDbContext _dbContext;

        public EnterpriseService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.Enterprise> GetAll()
        {
            var records = _dbContext.Set<Models.Enterprise>()
                .Include(x => x.Projects)
                .Include(x => x.MonetaryAgents)
                .ToList();
            return records;
        }

        public IEnumerable<Models.Enterprise> GetAllForResolver()
        {
            var records = _dbContext.Set<Models.Enterprise>().ToList();
            return records;
        }

        public int Save(Models.Enterprise entity)
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
                .Set<Models.Enterprise>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }
    }
}