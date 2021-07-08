using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Client.Services
{
    public interface IAppointmentDataService
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentDetails(int appointmentId);
        Task<Appointment> AddAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(int appointmentId);
    }
}
