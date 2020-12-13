using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                .Include(x => x.Attachments)
                .ToList();
            return records;
        }

        public override Project Get(int id)
        {
            var records = _dbContext.Set<Project>()
                .Include(x => x.Attachments)
                .Single(x => x.Id == id);
            return records;
        }

        public override int SaveAttachments(string[] files, int projectId)
        {
            // open mega.nz connection
            MegaApiClient client = new MegaApiClient();
            string megaUsername = _configuration[UsernameConfigPath];
            string megaPassword = _configuration[PasswordConfigPath];
            client.Login(megaUsername, megaPassword);
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // prepare string
                    var splitString = file.Split("||");
                    var fileBase64String = splitString.First();
                    var extension = splitString.Last();

                    // prepare file
                    var bytes = Convert.FromBase64String(fileBase64String);
                    using MemoryStream stream = new MemoryStream();
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Seek(0, SeekOrigin.Begin);

                    // determine file name
                    var fileName = Guid.NewGuid().ToString();

                    // save file to mega.nz
                    var projectFolderName = $"{UploadFolderPath}{projectId}";
                    IEnumerable<INode> nodes = client.GetNodes();
                    INode cloudFolder = nodes.SingleOrDefault(x => x.Type == NodeType.Directory && x.Name == projectFolderName);

                    if (cloudFolder == null)
                    {
                        INode root = nodes.Single(x => x.Type == NodeType.Root);
                        cloudFolder = client.CreateFolder(projectFolderName, root);
                    }

                    INode cloudFile = client.Upload(stream, $"{fileName}.{extension}", cloudFolder);
                    Uri downloadLink = client.GetDownloadLink(cloudFile);

                    // prepare entity
                    var entity = new Attachment
                    {
                        Name = fileName,
                        Url = downloadLink.AbsoluteUri,
                        ProjectId = projectId,
                        ExtensionType = extension
                    };
                    _dbContext.Add(entity);
                }
            }
            // close mega.nz connection
            client.Logout();

            return _dbContext.SaveChanges();
        }
    }
}