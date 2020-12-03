using System;

namespace InmobiliariaDashboard.Server.Models.Interfaces
{
    interface ISoftDeleteFields
    {
        bool SoftDelete { get; set; }
        DateTime? Deleted { get; set; }
        string DeletedBy { get; set; }
    }
}
