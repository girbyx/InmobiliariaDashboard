using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CG.Web.MegaApiClient;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Server.Extensions;
using InmobiliariaDashboard.Shared;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IBaseService<TEntity, out THistory> where TEntity : class where THistory : class
    {
        IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> function);
        IEnumerable<TEntity> GetAll();
        IEnumerable<THistory> GetHistory(int id);
        IEnumerable<TEntity> GetAllForResolver();
        TEntity Get(int id);
        int Save(TEntity entity, out int id);
        int SaveAttachments(string[] files, int id);
        int Delete(int id);
        int Archive(int id);
    }

    public class BaseService<TEntity, THistory> : IBaseService<TEntity, THistory>
        where TEntity : class
        where THistory : class
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public BaseService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> function)
        {
            var records = _dbContext.Set<TEntity>()
                .IncludeAll()
                .Where(function)
                .ToList();
            return records;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var records = _dbContext.Set<TEntity>()
                .IncludeAll()
                .ToList();
            return records;
        }

        public IEnumerable<THistory> GetHistory(int id)
        {
            var records = _dbContext.Set<THistory>()
                .IncludeAll()
                .Where(x => (x as IIAmHistory<TEntity>).OriginalId == id)
                .OrderByDescending(x => (x as IAuditFields).CreatedOn)
                .ToList();
            return records;
        }

        public virtual IEnumerable<TEntity> GetAllForResolver()
        {
            var records = _dbContext.Set<TEntity>()
                .IncludeAll()
                .ToList();
            return records;
        }

        public virtual TEntity Get(int id)
        {
            var records = _dbContext.Set<TEntity>()
                .IncludeAll()
                .Single(x => (x as IIdentityFields).Id == id);
            return records;
        }

        public virtual int Save(TEntity entity, out int id)
        {
            if ((entity as IIdentityFields).Id == 0)
                _dbContext.Add(entity);
            else
                _dbContext.Update(entity);

            _dbContext.SaveChanges();

            // history update
            if (typeof(THistory).Name.ToLower() != "object" && typeof(THistory).Name.ToLower() != "dynamic")
            {
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

        public virtual int SaveAttachments(string[] files, int id)
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

        protected int SaveToFileHosting(string[] files, int id, string folderPathConst)
        {
            // open mega.nz connection
            MegaApiClient client = new MegaApiClient();
            string megaUsername = _configuration[Constants.UsernameConfigPath];
            string megaPassword = _configuration[Constants.PasswordConfigPath];
            client.Login(megaUsername, megaPassword);

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // prepare string
                    var splitString = file.Split("||");
                    var fileBase64String = splitString.First();

                    // prepare file
                    var bytes = Convert.FromBase64String(fileBase64String);
                    using MemoryStream stream = new MemoryStream();
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Seek(0, SeekOrigin.Begin);

                    // determine file name
                    var fileName = splitString.Length > 2 ? splitString[1] : Guid.NewGuid().ToString();

                    // save file to mega.nz
                    var folderPath = $"{folderPathConst}{id}";
                    IEnumerable<INode> nodes = client.GetNodes();
                    INode cloudFolder =
                        nodes.SingleOrDefault(x => x.Type == NodeType.Directory && x.Name == folderPath);

                    if (cloudFolder == null)
                    {
                        INode root = nodes.Single(x => x.Type == NodeType.Root);
                        cloudFolder = client.CreateFolder(folderPath, root);
                    }

                    var extension = splitString.Last();
                    INode cloudFile = client.Upload(stream, $"{fileName}.{extension}", cloudFolder);
                    Uri downloadLink = client.GetDownloadLink(cloudFile);

                    // prepare entity
                    var entity = new Attachment
                    {
                        Name = fileName,
                        Url = downloadLink.AbsoluteUri,
                        ExtensionType = extension
                    };
                    DetermineEntityNavigation(entity, folderPathConst, id);

                    _dbContext.Add(entity);
                }
            }

            // close mega.nz connection
            client.Logout();

            return _dbContext.SaveChanges();
        }

        protected void DetermineEntityNavigation(Attachment entity, string folderPathConst, int id)
        {
            if (folderPathConst == Constants.ProjectFolderPath)
            {
                entity.ProjectId = id;
            }
            else if (folderPathConst == Constants.CostFolderPath)
            {
                entity.CostId = id;
            }
            else if (folderPathConst == Constants.GainFolderPath)
            {
                entity.GainId = id;
            }
            else if (folderPathConst == Constants.LossFolderPath)
            {
                entity.LossId = id;
            }
        }
    }
}