using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CG.Web.MegaApiClient;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ICostService : IBaseService<Cost, object>
    {
    }

    public class CostService : BaseService<Cost, object>, ICostService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public CostService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public override IEnumerable<Cost> GetAll()
        {
            var records = _dbContext.Set<Cost>()
                .Include(x => x.CostType)
                .Include(x => x.Project)
                .Include(x => x.MonetaryAgent)
                .ToList();
            return records;
        }

        public override int SaveAttachments(string[] files, int costId)
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
                    var extension = splitString.Last();

                    // prepare file
                    var bytes = Convert.FromBase64String(fileBase64String);
                    using MemoryStream stream = new MemoryStream();
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Seek(0, SeekOrigin.Begin);

                    // determine file name
                    var fileName = Guid.NewGuid().ToString();

                    // save file to mega.nz
                    var projectFolderName = $"{Constants.CostFolderPath}{costId}";
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
                        CostId = costId,
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