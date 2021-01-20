using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ReminderViewModel
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        [Required] public DateTime RecurrentOn { get; set; }
        [Required] public string ReminderFrequency { get; set; }
        public DateTime NextOccurrence { get; set; }
        public double DaysForNextOccurrence { get; set; }
        public double HoursForNextOccurrence { get; set; }
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una entidad")]
        public int PeopleId { get; set; }

        public string PeopleName { get; set; }

        // select lists
        public IEnumerable<PeopleViewModel> Peoples { get; set; }
    }
}