using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Server.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ICostService : IBaseService<Cost>
    {
    }

    public class CostService : ICostService
    {
        private readonly IApplicationDbContext _dbContext;

        public CostService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Cost> GetAll()
        {
            var records = _dbContext.Set<Cost>()
                .Include(x => x.CostType)
                .Include(x => x.Project)
                .Include(x => x.MonetaryAgent)
                .ToList();
            return records;
        }

        public IEnumerable<Cost> GetAllForResolver()
        {
            var records = _dbContext.Set<Cost>().ToList();
            return records;
        }

        public int Save(Cost entity)
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
                .Set<Cost>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }
    }
}