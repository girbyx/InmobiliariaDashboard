using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CG.Web.MegaApiClient;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IAttachmentService : IBaseService<Attachment, object>
    {
    }

    public class AttachmentService : BaseService<Attachment, object>, IAttachmentService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AttachmentService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public override int Delete(int id)
        {
            var record = _dbContext
                .Set<Attachment>()
                .First(x => x.Id == id);

            // delete from mega.nz
            var folderName = GetFolderName(record);
            var fileName = $"{record.Name}.{record.ExtensionType}";
            MegaApiClient client = new MegaApiClient();
            string megaUsername = _configuration[Constants.UsernameConfigPath];
            string megaPassword = _configuration[Constants.PasswordConfigPath];
            client.Login(megaUsername, megaPassword);
            IEnumerable<INode> nodes = client.GetNodes();
            INode cloudFile = nodes.SingleOrDefault(x => x.Type == NodeType.File && x.Name == fileName);
            if(cloudFile != null)
                client.Delete(cloudFile);
            client.Logout();

            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }

        private string GetFolderName(Attachment record)
        {
            var folderName = "";
            if (record.ProjectId.HasValue)
            {
                folderName = $"{Constants.ProjectFolderPath}{record.ProjectId}";
            }
            else if (record.CostId.HasValue)
            {
                folderName = $"{Constants.CostFolderPath}{record.CostId}";
            }
            else if (record.GainId.HasValue)
            {
                folderName = $"{Constants.GainFolderPath}{record.GainId}";
            }
            else if (record.LossId.HasValue)
            {
                folderName = $"{Constants.LossFolderPath}{record.LossId}";
            }

            return folderName;
        }
    }
}