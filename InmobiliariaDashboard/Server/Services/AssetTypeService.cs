using System.Collections.Generic;
using System.Linq;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IAssetTypeService : IBaseService<AssetType>
    {
    }

    public class AssetTypeService : IAssetTypeService
    {
        private readonly IApplicationDbContext _dbContext;

        public AssetTypeService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AssetType> GetAll()
        {
            var records = _dbContext.Set<AssetType>()
                .Include(x => x.Assets)
                .ToList();
            return records;
        }

        public IEnumerable<AssetType> GetAllForResolver()
        {
            var records = _dbContext.Set<AssetType>().ToList();
            return records;
        }
    }
}