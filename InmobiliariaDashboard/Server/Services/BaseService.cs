using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models.Interfaces;
using Microsoft.AspNetCore.Http;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IBaseService<TEntity, THistory> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllForResolver();
        TEntity Get(int id);
        int Save(TEntity entity, out int id);
        int SaveAttachments(IEnumerable<IFormFile> files, int id);
        int Delete(int id);
        int Archive(int id);
    }

    public class BaseService<TEntity, THistory> : IBaseService<TEntity, THistory>
        where TEntity : class
        where THistory : class
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public BaseService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var records = _dbContext.Set<TEntity>().ToList();
            return records;
        }

        public virtual IEnumerable<TEntity> GetAllForResolver()
        {
            var records = _dbContext.Set<TEntity>().ToList();
            return records;
        }

        public TEntity Get(int id)
        {
            var records = _dbContext.Set<TEntity>().Single(x => (x as IIdentityFields).Id == id);
            return records;
        }

        public virtual int Save(TEntity entity, out int id)
        {
            if ((entity as IIdentityFields).Id == 0)
                _dbContext.Add(entity);
            else
                _dbContext.Update(entity);

            // history update
            if (typeof(THistory).Name.ToLower() != "object" && typeof(THistory).Name.ToLower() != "dynamic")
            {
                _dbContext.SaveChanges();
                var historyRecord = _mapper.Map<THistory>(entity);
                (historyRecord as IIAmHistory<TEntity>).Id = 0;
                (historyRecord as IIAmHistory<TEntity>).OriginalId = (entity as IIdentityFields).Id;
                (historyRecord as IAuditFields).CreatedOn = DateTime.Now;
                (historyRecord as IAuditFields).CreatedBy = string.Empty;
                _dbContext.Add(historyRecord);
            }

            id = (entity as IIdentityFields).Id;
            return _dbContext.SaveChanges();
        }

        public virtual int SaveAttachments(IEnumerable<IFormFile> files, int id)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(int id)
        {
            var record = _dbContext
                .Set<TEntity>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }

        public virtual int Archive(int id)
        {
            var record = _dbContext
                .Set<TEntity>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Archive(record);
            return _dbContext.SaveChanges();
        }
    }
}