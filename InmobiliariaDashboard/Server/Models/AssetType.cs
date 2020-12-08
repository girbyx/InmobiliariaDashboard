using System;
using System.Collections.Generic;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class AssetType : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // audit & relationships
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Asset> Assets { get; set; }
    }

    public class AssetTypeProfile : Profile
    {
        public AssetTypeProfile()
        {
            CreateMap<AssetType, AssetTypeViewModel>();
            CreateMap<AssetTypeViewModel, AssetType>();
        }
    }
}