using System;
using System.Collections.Generic;
using InmobiliariaDashboard.Server.Models.Interfaces;

namespace InmobiliariaDashboard.Server.Models
{
    public class Account : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AccountNumber { get; set; }
        public int? CardNumber { get; set; }
        public string Type { get; set; }

        // audit & relationships
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Gain> Gains { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<Loss> Losses { get; set; }
    }
}