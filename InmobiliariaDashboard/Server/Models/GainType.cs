using System;
using System.Collections.Generic;
using InmobiliariaDashboard.Server.Models.Interfaces;

namespace InmobiliariaDashboard.Server.Models
{
    public class GainType : IIdentityFields, IAuditFields
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
        public virtual ICollection<Gain> Gains { get; set; }
    }
}