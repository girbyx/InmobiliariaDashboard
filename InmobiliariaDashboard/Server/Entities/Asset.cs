﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using InmobiliariaDashboard.Server.AutomapperResolvers;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
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
        public int PeopleId { get; set; }
        public virtual People People { get; set; }
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
                .ForMember(dest => dest.Peoples, opt => opt.MapFrom<PeoplesResolver>())
                .ForMember(dest => dest.AssetTypes, opt => opt.MapFrom<AssetTypesResolver>());
            CreateMap<AssetViewModel, Asset>();
        }
    }
}