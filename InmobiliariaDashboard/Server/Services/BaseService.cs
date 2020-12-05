using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IBaseService<out TViewModel> where TViewModel : class
    {
        IEnumerable<TViewModel> GetAll();
    }

    public class BaseService<TEntity, TViewModel> : IBaseService<TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public BaseService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<TViewModel> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList().Select(_mapper.Map<TViewModel>);
        }
    }
}
