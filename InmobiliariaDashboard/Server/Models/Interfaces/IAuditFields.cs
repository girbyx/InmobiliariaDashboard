using System;

namespace InmobiliariaDashboard.Server.Models.Interfaces
{
    interface IAuditFields
    {
        DateTime Created { get; set; }
        string CreatedBy { get; set; }
        DateTime? Updated { get; set; }
        string UpdatedBy { get; set; }
    }
}
