using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Elders
{
    public class ElderIndexBase : ComponentBase
    {
        [Inject]
        public IElderDataService ElderDataService { get; set; }
        public List<Elder> Elders { get; set; }

        [Inject]
        public ICaretakerDataService CaretakerDataService { get; set; }
        public List<Caretaker> Caretakers { get; set; }

        protected override async Task OnInitializedAsync()
        {


            Elders = (await ElderDataService.GetAllElders()).ToList();

            Caretakers = (await CaretakerDataService.GetAllCaretakers()).ToList();

        }
    }
}
