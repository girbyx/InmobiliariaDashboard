using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ILossTypeService : IBaseService<LossType, object>
    {
    }

    public class LossTypeService : BaseService<LossType, object>, ILossTypeService
    {
        public LossTypeService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
        }
    }
}