﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Contact
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<ContactViewModel> OriginalRecords;
        public IEnumerable<ContactViewModel> Records;

        protected async Task FilterRecords(ChangeEventArgs e)
        {
            var searchValue = e.Value.ToString().ToLower();
            Records = OriginalRecords.Where(x =>
                x.Name.ToLower().Contains(searchValue)
                || x.Email.ToLower().Contains(searchValue)
                || x.EnterpriseName.ToLower().Contains(searchValue));
        }

        protected override async Task OnInitializedAsync()
        {
            Records = OriginalRecords = await Service.GetList();
        }
    }
}