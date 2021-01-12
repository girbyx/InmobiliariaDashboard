﻿using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Interfaces;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ProjectSubTypeViewModel : IISelectableViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectType { get; set; }
    }
}