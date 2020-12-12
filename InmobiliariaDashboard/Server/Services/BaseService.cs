using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models.Interfaces;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllForResolver();
        int Save(TEntity entity);
        int Delete(int id);
    }

    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IApplicationDbContext _dbContext;

        public BaseService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var records = _dbContext.Set<TEntity>().ToList();
            return records;
        }

        public IEnumerable<TEntity> GetAllForResolver()
        {
            var records = _dbContext.Set<TEntity>().ToList();
            return records;
        }

        public int Save(TEntity entity)
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
                .Set<TEntity>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }
    }
}