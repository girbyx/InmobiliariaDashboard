﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IContactService : IBaseService<Contact, object>
    {
    }

    public class ContactService : BaseService<Contact, object>, IContactService
    {
        private readonly IApplicationDbContext _dbContext;

        public ContactService(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<Contact> GetAll()
        {
            var records = _dbContext.Set<Contact>()
                .Include(x => x.Enterprise)
                .ToList();
            return records;
        }
    }
}