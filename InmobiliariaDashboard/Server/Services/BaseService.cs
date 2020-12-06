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
        protected readonly IApplicationDbContext _dbContext;

        public BaseService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }
    }
}
