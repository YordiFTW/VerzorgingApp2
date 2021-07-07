using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Elders
{
    public class ElderDetailBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public Elder Elder { get; set; } = new Elder();

        public IEnumerable<Elder> Elders { get; set; }
        [Inject]
        public IElderDataService ElderDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Elder = await ElderDataService.GetElderDetails(int.Parse(Id));

        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/Elders/ElderIndex");
        }
    }
}
