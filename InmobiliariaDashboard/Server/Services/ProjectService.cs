using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Server.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IProjectService : IBaseService<Project>
    {
    }

    public class ProjectService : IProjectService
    {
        private readonly IApplicationDbContext _dbContext;

        public ProjectService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Project> GetAll()
        {
            var records = _dbContext.Set<Project>()
                .Include(x => x.Enterprise)
                .ToList();
            return records;
        }
        public IEnumerable<Project> GetAllForResolver()
        {
            var records = _dbContext.Set<Project>().ToList();
            return records;
        }

        public int Save(Project entity)
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
                .Set<Project>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }
    }
}