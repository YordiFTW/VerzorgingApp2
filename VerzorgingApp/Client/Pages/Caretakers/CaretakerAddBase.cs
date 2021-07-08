using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Caretakers
{
    public class CaretakerAddBase : ComponentBase
    {
        [Inject]
        public ICaretakerDataService CaretakerDataService { get; set; }

        [Inject]
        public IElderDataService ElderDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Caretaker Caretaker { get; set; } = new Caretaker();

        public List<Elder> Elders { get; set; } = new List<Elder>();




        [Parameter]
        public int Id { get; set; }
        

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override async Task OnInitializedAsync()
        {
            Elders = (await ElderDataService.GetAllElders()).ToList();

            Saved = false;
            Caretaker = new Caretaker
            {
                //Date = DateTime.Now
            };

        }

        protected async Task HandleValidSubmit()
        {
            if (Caretaker.Id == 0) //new
            {
                Caretaker.Id = Id;

                var addedPlan = await CaretakerDataService.AddCaretaker(Caretaker);
                if (addedPlan != null)
                {
                    StatusClass = "alert-success";
                    Message = "Nieuwe afspraak succesvol toegevoegd.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Er is iets misgegaan tijdens het aanmaken van een nieuwe afspraak. Probeer het opnieuw.";
                    Saved = false;
                }
            }
            else
            {
                await CaretakerDataService.UpdateCaretaker(Caretaker);
                StatusClass = "alert-success";
                Message = "Afspraakgegevens zijn succesvol bijgewerkt.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeletePlan()
        {
            await CaretakerDataService.DeleteCaretaker(Caretaker.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Caretakers/CaretakerIndex");
        }
    }
}
