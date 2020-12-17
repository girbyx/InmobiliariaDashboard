using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Server.Resolvers;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class Asset : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        [NotMapped] public double SubTotal => Value * Quantity;
        public string Description { get; set; }

        // audit & relationships
        public int EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public int AssetTypeId { get; set; }
        public virtual AssetType AssetType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetViewModel>()
                .ForMember(dest => dest.Enterprises, opt => opt.MapFrom<EnterprisesResolver>())
                .ForMember(dest => dest.AssetTypes, opt => opt.MapFrom<AssetTypesResolver>());
            CreateMap<AssetViewModel, Asset>();
        }
    }
}