using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IEnterpriseService : IBaseService<Enterprise, object>
    {
    }

    public class EnterpriseService : BaseService<Enterprise, object>, IEnterpriseService
    {
        public EnterpriseService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
        }
    }
}