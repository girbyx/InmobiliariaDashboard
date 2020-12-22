using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IGainTypeService : IBaseService<GainType, object>
    {
    }

    public class GainTypeService : BaseService<GainType, object>, IGainTypeService
    {

        public GainTypeService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
        }
    }
}