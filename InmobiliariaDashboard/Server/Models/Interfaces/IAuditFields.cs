﻿using System;

namespace InmobiliariaDashboard.Server.Models.Interfaces
{
    interface IAuditFields
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
        string UpdatedBy { get; set; }
    }
}
