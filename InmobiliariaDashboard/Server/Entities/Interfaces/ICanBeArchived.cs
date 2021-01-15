using System;

namespace InmobiliariaDashboard.Server.Entities.Interfaces
{
    interface ICanBeArchived
    {
        bool Archived { get; set; }
        DateTime? ArchivedOn { get; set; }
        string ArchivedBy { get; set; }
    }
}
