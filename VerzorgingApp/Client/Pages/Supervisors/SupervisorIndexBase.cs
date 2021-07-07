using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Supervisors
{
    public class SupervisorIndexBase : ComponentBase
    {
        [Inject]
        public ISupervisorDataService SupervisorDataService { get; set; }
        public List<Supervisor> Supervisors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Supervisors = (await SupervisorDataService.GetAllSupervisors()).ToList();

        }
    }
}
