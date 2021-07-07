using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Supervisors
{
    public class SupervisorAddBase : ComponentBase
    {
        [Inject]
        public ISupervisorDataService SupervisorDataService { get; set; }
        //[Inject]
        //public ICaretakerDataService CaretakerDataService { get; set; }
        //public List<Caretaker> Caretakers { get; set; } = new List<Caretaker>();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

       
        public Supervisor Supervisor { get; set; } = new Supervisor();
        




        [Parameter]
        public int Id { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override async Task OnInitializedAsync()
        {
            //Caretakers = (await CaretakerDataService.GetAllCaretakers()).ToList();

            Saved = false;
            Supervisor = new Supervisor
            {
                //Date = DateTime.Now
            };

        }

        protected async Task HandleValidSubmit()
        {
            if (Supervisor.Id == 0) //new
            {
                Supervisor.Id = Id;

                var addedPlan = await SupervisorDataService.AddSupervisor(Supervisor);
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
                await SupervisorDataService.UpdateSupervisor(Supervisor);
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
            await SupervisorDataService.DeleteSupervisor(Supervisor.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Supervisors/SupervisorIndex");
        }
    }
}
