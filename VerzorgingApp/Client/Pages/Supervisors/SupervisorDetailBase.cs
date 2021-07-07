using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Supervisors
{
    public class SupervisorDetailBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public Supervisor Supervisor { get; set; } = new Supervisor();

        public IEnumerable<Supervisor> Supervisors { get; set; }
        [Inject]
        public ISupervisorDataService SupervisorDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Supervisor = await SupervisorDataService.GetSupervisorDetails(int.Parse(Id));

        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/Supervisors/SupervisorIndex");
        }
    }
}
