using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VerzorgingApp.Server.Models;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepo _appointmentrepo;

        public AppointmentController(IAppointmentRepo appointmentRepository)
        {
            _appointmentrepo = appointmentRepository;
        }

        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            return Ok(_appointmentrepo.GetAllAppointments());
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(int id)
        {
            return Ok(_appointmentrepo.GetAppointmentById(id));
        }

        [HttpPost]
        public IActionResult CreateAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
                return BadRequest();

            if (appointment.Subject == string.Empty || appointment.CategoryColor == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAppointment = _appointmentrepo.AddAppointment(appointment);

            return Created("appointment", createdAppointment);
        }

        [HttpPut]
        public IActionResult UpdateAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
                return BadRequest();

            if (appointment.Subject == string.Empty || appointment.CategoryColor == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appointmentToUpdate = _appointmentrepo.GetAppointmentById(appointment.Id);

            if (appointmentToUpdate == null)
                return NotFound();

            _appointmentrepo.UpdateAppointment(appointment);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            if (id == 0)
                return BadRequest();

            var appointmentToDelete = _appointmentrepo.GetAppointmentById(id);
            if (appointmentToDelete == null)
                return NotFound();

            _appointmentrepo.DeleteAppointment(id);

            return NoContent();//success
        }
    }
}
