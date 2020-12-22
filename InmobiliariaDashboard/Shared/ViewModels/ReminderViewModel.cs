using System;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ReminderViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime RecurrentOn { get; set; }
        [Required]
        public string ReminderType { get; set; }
        public string Description { get; set; }
    }
}