using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CG.Web.MegaApiClient;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IAttachmentService : IBaseService<Attachment, object>
    {
        int SaveProjectAttachments(IEnumerable<IFormFile> files, int projectId);
    }

    public class AttachmentService : BaseService<Attachment, object>, IAttachmentService
    {
        private const string UploadFolderPath = "ProjectUploads_ProjectID_";
        private const string UsernameConfigPath = "MegaClientApi:Credentials:Username";
        private const string PasswordConfigPath = "MegaClientApi:Credentials:Password";
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AttachmentService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public int SaveProjectAttachments(IEnumerable<IFormFile> files, int projectId)
        {
            MegaApiClient client = new MegaApiClient();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using var stream = File.Create(filePath);
                    file.CopyTo(stream);

                    // mega.nz connection
                    string megaUsername = _configuration[UsernameConfigPath];
                    string megaPassword = _configuration[PasswordConfigPath];
                    client.Login(megaUsername, megaPassword);
                    IEnumerable<INode> nodes = client.GetNodes();
                    INode root = nodes.Single(x => x.Type == NodeType.Root);
                    INode myFolder = client.CreateFolder($"{UploadFolderPath}{projectId}", root);
                    INode myFile = client.Upload(stream, file.FileName, myFolder);
                    Uri downloadLink = client.GetDownloadLink(myFile);

                    // prepare entity
                    var entity = new Attachment
                    {
                        Name = file.FileName,
                        Url = downloadLink.AbsoluteUri,
                        ProjectId = projectId,
                        Type = string.Empty
                    };
                    _dbContext.Add(entity);
                }
            }
            client.Logout();

            return _dbContext.SaveChanges();
        }
    }
}