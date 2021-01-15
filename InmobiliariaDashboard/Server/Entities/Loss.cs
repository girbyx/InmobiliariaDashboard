﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using InmobiliariaDashboard.Server.AutomapperResolvers;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
{
    public class Loss : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        [NotMapped] public double SubTotal => Value * Quantity;
        public double Commission { get; set; }
        public string CommissionType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public double Total => CommissionTypeEnum.Money.Code == CommissionType ? (SubTotal + Commission) :
            CommissionTypeEnum.Percentage.Code == CommissionType ? (SubTotal * (1 + (Commission / 100))) : SubTotal;

        // audit & relationships
        public int LossTypeId { get; set; }
        public virtual LossType LossType { get; set; }
        public int PeopleId { get; set; }
        public virtual People People { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Attachment> Attachments { get; set; }
    }

    public class LossProfile : Profile
    {
        public LossProfile()
        {
            CreateMap<Loss, LossViewModel>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId ?? 0))
                .ForMember(dest => dest.LossTypes, opt => opt.MapFrom<LossTypesResolver>())
                .ForMember(dest => dest.Peoples, opt => opt.MapFrom<PeoplesResolver>())
                .ForMember(dest => dest.Projects, opt => opt.MapFrom<ProjectsResolver>());
            CreateMap<LossViewModel, Loss>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId == 0 ? null : (int?)src.ProjectId));
        }
    }
}