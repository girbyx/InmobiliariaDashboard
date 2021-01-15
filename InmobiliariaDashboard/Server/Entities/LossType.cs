using System;
using System.Collections.Generic;
using AutoMapper;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
{
    public class LossType : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // audit & relationships
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Loss> Losses { get; set; }
    }

    public class LossTypeProfile : Profile
    {
        public LossTypeProfile()
        {
            CreateMap<LossType, LossTypeViewModel>();
            CreateMap<LossTypeViewModel, LossType>();
        }
    }
}