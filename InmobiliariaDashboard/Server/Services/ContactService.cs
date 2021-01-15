using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IContactService : IBaseService<Contact, object>
    {
    }

    public class ContactService : BaseService<Contact, object>, IContactService
    {
        public ContactService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
        }
    }
}