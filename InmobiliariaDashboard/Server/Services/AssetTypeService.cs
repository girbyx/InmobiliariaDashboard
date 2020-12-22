using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IAssetTypeService : IBaseService<AssetType, object>
    {
    }

    public class AssetTypeService : BaseService<AssetType, object>, IAssetTypeService
    {
        public AssetTypeService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
        }
    }
}