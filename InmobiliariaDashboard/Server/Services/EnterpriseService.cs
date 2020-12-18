using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IEnterpriseService : IBaseService<Models.Enterprise, object>
    {
    }

    public class EnterpriseService : BaseService<Models.Enterprise, object>, IEnterpriseService
    {
        public EnterpriseService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
        }
    }
}