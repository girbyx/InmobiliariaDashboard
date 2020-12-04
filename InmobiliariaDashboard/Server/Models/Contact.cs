using System;
using System.ComponentModel.DataAnnotations.Schema;
using InmobiliariaDashboard.Server.Models.Interfaces;

namespace InmobiliariaDashboard.Server.Models
{
    public class Contact : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string SuffixName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [NotMapped] public string FullName => string.Join("", SuffixName, FirstName, MiddleName, LastName);
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string AddressExt { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }

        // audit & relationships
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}