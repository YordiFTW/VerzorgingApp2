using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Elders
{
    public class ElderEditBase : ComponentBase
    {
        [Inject]
        public IElderDataService ElderDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Elder Elder { get; set; } = new Elder();


        [Parameter]
        public string Id { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override async Task OnInitializedAsync()
        {
            Saved = false;


            int.TryParse(Id, out var ElderID);

            if (ElderID == 0) //new Customer is being created
            {
                //add some defaults
                Elder = new Elder
                {
                    //Date = DateTime.Now
                };
            }
            else
            {
                Elder = await ElderDataService.GetElderDetails(int.Parse(Id));
            }


        }

        protected async Task HandleValidSubmit()
        {


            if (Elder.Id == 0) //new
            {
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
            NavigationManager.NavigateTo("/Planner/PlanIndex");
        }
    }
}
