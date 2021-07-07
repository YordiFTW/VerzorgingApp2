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
    public class SupervisorController : ControllerBase
    {
        private readonly ISupervisorRepo _elderrepo;

        public SupervisorController(ISupervisorRepo elderRepository)
        {
            _elderrepo = elderRepository;
        }

        [HttpGet]
        public IActionResult GetAllSupervisors()
        {
            return Ok(_elderrepo.GetAllSupervisors());
        }

        [HttpGet("{id}")]
        public IActionResult GetSupervisorById(int id)
        {
            return Ok(_elderrepo.GetSupervisorById(id));
        }

        [HttpPost]
        public IActionResult CreateSupervisor([FromBody] Supervisor elder)
        {
            if (elder == null)
                return BadRequest();

            if (elder.FirstName == string.Empty || elder.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdSupervisor = _elderrepo.AddSupervisor(elder);

            return Created("elder", createdSupervisor);
        }

        [HttpPut]
        public IActionResult UpdateSupervisor([FromBody] Supervisor elder)
        {
            if (elder == null)
                return BadRequest();

            if (elder.FirstName == string.Empty || elder.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var elderToUpdate = _elderrepo.GetSupervisorById(elder.Id);

            if (elderToUpdate == null)
                return NotFound();

            _elderrepo.UpdateSupervisor(elder);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupervisor(int id)
        {
            if (id == 0)
                return BadRequest();

            var elderToDelete = _elderrepo.GetSupervisorById(id);
            if (elderToDelete == null)
                return NotFound();

            _elderrepo.DeleteSupervisor(id);

            return NoContent();//success
        }
    }
}
