using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Server.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ICostTypeService : IBaseService<CostType>
    {
    }

    public class CostTypeService : ICostTypeService
    {
        private readonly IApplicationDbContext _dbContext;

        public CostTypeService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CostType> GetAll()
        {
            var records = _dbContext.Set<CostType>()
                .Include(x => x.Costs)
                .ToList();
            return records;
        }

        public IEnumerable<CostType> GetAllForResolver()
        {
            var records = _dbContext.Set<CostType>().ToList();
            return records;
        }

        public int Save(CostType entity)
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
                .Set<CostType>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }
    }
}