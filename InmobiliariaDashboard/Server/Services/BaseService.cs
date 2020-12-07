using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IBaseService<out TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
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
    }
}
