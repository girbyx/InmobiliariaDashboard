using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using AutoMapper;
using CG.Web.MegaApiClient;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IProjectService : IBaseService<Project, ProjectHistory>
    {
    }

    public class ProjectService : BaseService<Project, ProjectHistory>, IProjectService
    {
        private const string UploadFolderPath = "ProjectUploads_ProjectID_";
        private const string UsernameConfigPath = "MegaClientApi:Credentials:Username";
        private const string PasswordConfigPath = "MegaClientApi:Credentials:Password";
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ProjectService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public override IEnumerable<Project> GetAll()
        {
            var records = _dbContext.Set<Project>()
                .Include(x => x.Enterprise)
                .ToList();
            return records;
        }

        public override int SaveAttachments(string[] files, int projectId)
        {
            MegaApiClient client = new MegaApiClient();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var bytes = Convert.FromBase64String(file);
                    using MemoryStream stream = new MemoryStream();
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Seek(0, SeekOrigin.Begin);

                    // determine file name
                    var fileName = Guid.NewGuid().ToString();

                    // mega.nz connection
                    string megaUsername = _configuration[UsernameConfigPath];
                    string megaPassword = _configuration[PasswordConfigPath];
                    //client.Login(megaUsername, megaPassword);
                    //IEnumerable<INode> nodes = client.GetNodes();
                    //INode root = nodes.Single(x => x.Type == NodeType.Root);
                    //INode cloudFolder = client.CreateFolder($"{UploadFolderPath}{projectId}", root);
                    //INode cloudFile = client.Upload(stream, fileName, cloudFolder);
                    //Uri downloadLink = client.GetDownloadLink(cloudFile);

                    //// prepare entity
                    //var entity = new Attachment
                    //{
                    //    Name = fileName,
                    //    Url = downloadLink.AbsoluteUri,
                    //    ProjectId = projectId,
                    //    Type = string.Empty
                    //};
                    //_dbContext.Add(entity);
                }
            }
            //client.Logout();

            return _dbContext.SaveChanges();
        }
    }
}