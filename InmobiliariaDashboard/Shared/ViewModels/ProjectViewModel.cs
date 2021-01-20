﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Interfaces;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ProjectViewModel : ISelectableViewModel, IFileUploader
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Code { get; set; }
        public string Description { get; set; }
        [Required] public string ProjectType { get; set; }
        public bool Sold { get; set; }
        public double PurchasePrice { get; set; }
        public double MinimumSellingPrice { get; set; }
        public double MaximumSellingPrice { get; set; }
        [Required] public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Prospect { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una entidad")]
        public int PeopleId { get; set; }
        public string PeopleName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione un sub-tipo")]
        public int ProjectSubTypeId { get; set; }
        public string ProjectSubTypeName { get; set; }

        // select lists
        public IEnumerable<PeopleViewModel> Peoples { get; set; }
        public IEnumerable<ProjectSubTypeViewModel> ProjectSubTypes { get; set; }

        // lists
        public IEnumerable<ContactViewModel> EnterpriseContacts { get; set; }
        public IEnumerable<AttachmentViewModel> Attachments { get; set; }
    }
}