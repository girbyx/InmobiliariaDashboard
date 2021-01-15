﻿using System.Net;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Login
{
    public class LoginBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public LoginUserViewModel Record { get; set; } = new LoginUserViewModel();

        protected async Task HandleValidSubmit()
        {
            var statusCode = await Service.Login(Record);
            if(statusCode == HttpStatusCode.OK)
                await Service.GoBackHome();
        }

        protected async Task Logout()
        {
            await Service.Logout();
            await Service.GoBackHome();
        }
    }
}