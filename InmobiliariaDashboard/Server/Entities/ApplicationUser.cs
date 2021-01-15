using System;
using InmobiliariaDashboard.Server.Entities.Interfaces;

namespace InmobiliariaDashboard.Server.Entities
{
    public class ApplicationUser : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
