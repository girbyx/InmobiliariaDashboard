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
                x.EnterpriseName.ToLower().Contains(searchValue)
                || x.Name.ToLower().Contains(searchValue)
                || x.Email.ToLower().Contains(searchValue)
                || x.Cellphone.ToLower().Contains(searchValue)
                || x.Address.ToLower().Contains(searchValue)
                || (x.Prospect ? "si".Contains(searchValue) : "no".Contains(searchValue)));
        }

        protected override async Task OnInitializedAsync()
        {
            Records = OriginalRecords = await Service.GetList();
        }

        protected async Task OnDeleteClick(int id)
        {
            await Service.Delete(id);
            OriginalRecords = OriginalRecords.Where(x => x.Id != id);
            Records = Records.Where(x => x.Id != id);
        }
    }
}