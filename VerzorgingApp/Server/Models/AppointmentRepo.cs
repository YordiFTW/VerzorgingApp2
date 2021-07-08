using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerzorgingApp.Server.Data;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Server.Models
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ApplicationDbContext _mBDbContext;

        public AppointmentRepo(ApplicationDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            var addAppointment = _mBDbContext.Appointments.Add(appointment);
            _mBDbContext.SaveChanges();
            return addAppointment.Entity;
        }

        public void DeleteAppointment(int appointmentId)
        {
            var Appointment = _mBDbContext.Appointments.FirstOrDefault(e => e.Id == appointmentId);
            if (Appointment == null) return;

            _mBDbContext.Appointments.Remove(Appointment);
            _mBDbContext.SaveChanges();
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _mBDbContext.Appointments;
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return _mBDbContext.Appointments.FirstOrDefault(c => c.Id == appointmentId);
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var updateAppointment = _mBDbContext.Appointments.FirstOrDefault(e => e.Id == appointment.Id);

            if (updateAppointment != null)
            {
                updateAppointment.CategoryColor = appointment.CategoryColor;
                updateAppointment.EndTime = appointment.EndTime;
                updateAppointment.StartTime = appointment.StartTime;
                updateAppointment.Subject = appointment.Subject;

                _mBDbContext.SaveChanges();

                return updateAppointment;
            }
            return null;
        }
    }
}
