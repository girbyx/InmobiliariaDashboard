using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using InmobiliariaDashboard.Shared;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IGainService : IBaseService<Gain, object>
    {
    }

    public class GainService : BaseService<Gain, object>, IGainService
    {

        public GainService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
        }

        public override int SaveAttachments(string[] files, int costId)
        {
            if (files != null && files.Any())
            {
                return SaveToFileHosting(files, costId, Constants.CostFolderPath);
            }

            return 0;
        }
    }
}