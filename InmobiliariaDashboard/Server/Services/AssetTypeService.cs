using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IAssetTypeService : IBaseService<AssetType, object>
    {
    }

    public class AssetTypeService : BaseService<AssetType, object>, IAssetTypeService
    {
        private readonly IApplicationDbContext _dbContext;

        public AssetTypeService(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<AssetType> GetAll()
        {
            var records = _dbContext.Set<AssetType>()
                .Include(x => x.Assets)
                .ToList();
            return records;
        }
    }
}