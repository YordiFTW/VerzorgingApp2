using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using VerzorgingApp.Client.Services;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Pages.Calendar
{
    public class SchedulerBase : ComponentBase
    {

        [Inject]
        public IAppointmentDataService AppointmentDataService { get; set; }

        public DateTime CurrentDate = new DateTime(2020, 1, 9);
        public List<Appointment> Appointments { get; set; }
        //public class AppointmentData
        //{
        //    public int Id { get; set; }
        //    public string Subject { get; set; }
        //    public string Location { get; set; }
        //    public string Description { get; set; }
        //    public DateTime StartTime { get; set; }
        //    public DateTime EndTime { get; set; }
        //    public Nullable<bool> IsAllDay { get; set; }
        //    public string CategoryColor { get; set; }
        //    public string RecurrenceRule { get; set; }
        //    public Nullable<int> RecurrenceID { get; set; }
        //    public string RecurrenceException { get; set; }
        //    public string StartTimezone { get; set; }
        //    public string EndTimezone { get; set; }
        //}


        protected override async Task OnInitializedAsync()
        {
            Appointments = (await AppointmentDataService.GetAllAppointments()).ToList();
        }
    }
}
