using System;
using System.Collections.Generic;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public int ClientId { get; set; }
        public int ClientName { get; set; }

        // select lists
        public IEnumerable<ClientViewModel> Clients { get; set; }
    }
}