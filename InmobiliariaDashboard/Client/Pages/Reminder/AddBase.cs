﻿using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Reminder
{
    public class AddBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public ReminderViewModel Record { get; set; } = new ReminderViewModel();
        public IEnumerable<ReminderFrequencyEnum> ReminderFrequencies => BaseEnumeration.GetAll<ReminderFrequencyEnum>();

        protected override async Task OnInitializedAsync()
        {
            Record = await Service.GetEmpty();

            // defaults
            Record.ReminderFrequency = ReminderFrequencyEnum.Monthly.Code;
        }

        protected async Task HandleValidSubmit()
        {
            await Service.Add(Record);
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}