using System;
using System.Collections.Generic;
using InmobiliariaDashboard.Server.Models.Interfaces;

namespace InmobiliariaDashboard.Server.Models
{
    public class Loss : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public double Value { get; set; }

        // audit & relationships
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}