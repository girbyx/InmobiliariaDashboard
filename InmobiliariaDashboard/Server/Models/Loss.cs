﻿using System;
using System.Collections.Generic;
using InmobiliariaDashboard.Server.Models.Interfaces;

namespace InmobiliariaDashboard.Server.Models
{
    public class Loss : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        public double? Commission { get; set; }
        public string CommissionType { get; set; }
        public string Description { get; set; }

        // audit & relationships
        public int LossTypeId { get; set; }
        public virtual LossType LossType { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int MonetaryAgentId { get; set; }
        public virtual MonetaryAgent MonetaryAgent { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}