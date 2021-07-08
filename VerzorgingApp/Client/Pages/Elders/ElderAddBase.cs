using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Elders
{
    public class ElderAddBase : ComponentBase
    {
        [Inject]
        public IElderDataService ElderDataService { get; set; }

        [Inject]
        public ICaretakerDataService CaretakerDataService { get; set; }

        public List<Caretaker> Caretakers { get; set; } = new List<Caretaker>();

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Elder Elder { get; set; } = new Elder();

  


        [Parameter]
        public int Id { get; set; }


        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override async Task OnInitializedAsync()
        {

            Caretakers = (await CaretakerDataService.GetAllCaretakers()).ToList();

            

            Saved = false;
            Elder = new Elder
            {
                //Date = DateTime.Now
            };

        }

        protected async Task HandleValidSubmit()
        {
            if (Elder.Id == 0) //new
            {
                Elder.Id = Id;

                var addedPlan = await ElderDataService.AddElder(Elder);
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
                await ElderDataService.UpdateElder(Elder);
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
            await ElderDataService.DeleteElder(Elder.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Elders/ElderIndex");
        }
    }
}
