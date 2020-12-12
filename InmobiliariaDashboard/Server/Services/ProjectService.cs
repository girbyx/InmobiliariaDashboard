using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProjectService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            var historyRecord = _mapper.Map<ProjectHistory>(entity);
            historyRecord.Id = 0;
            if ((entity as IIdentityFields).Id == 0)
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                historyRecord.OriginalId = entity.Id;
                _dbContext.Add(historyRecord);
            }
            else
            {
                _dbContext.Update(entity);
                historyRecord.OriginalId = entity.Id;
                _dbContext.Update(historyRecord);
            }

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