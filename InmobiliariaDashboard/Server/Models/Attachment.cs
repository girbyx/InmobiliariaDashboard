using System;
using InmobiliariaDashboard.Server.Models.Interfaces;

namespace InmobiliariaDashboard.Server.Models
{
    public class Attachment : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }

        // audit & relationships
        public int? GainId { get; set; }
        public virtual Gain Gain { get; set; }
        public int? CostId { get; set; }
        public virtual Cost Cost { get; set; }
        public int? LossId { get; set; }
        public virtual Loss Loss { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}