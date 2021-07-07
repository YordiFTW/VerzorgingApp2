using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Caretakers
{
    public class CaretakerDetailBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public Caretaker Caretaker { get; set; } = new Caretaker();

        public IEnumerable<Caretaker> Caretakers { get; set; }
        [Inject]
        public ICaretakerDataService CaretakerDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Caretaker = await CaretakerDataService.GetCaretakerDetails(int.Parse(Id));

        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/Caretakers/CaretakerIndex");
        }
    }
}
