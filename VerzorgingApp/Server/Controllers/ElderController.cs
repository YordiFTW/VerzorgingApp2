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
    public class ElderController : ControllerBase
    {
        private readonly IElderRepo _elderrepo;

        public ElderController(IElderRepo elderRepository)
        {
            _elderrepo = elderRepository;
        }

        [HttpGet]
        public IActionResult GetAllElders()
        {
            return Ok(_elderrepo.GetAllElders());
        }

        [HttpGet("{id}")]
        public IActionResult GetElderById(int id)
        {
            return Ok(_elderrepo.GetElderById(id));
        }

        [HttpPost]
        public IActionResult CreateElder([FromBody] Elder elder)
        {
            if (elder == null)
                return BadRequest();

            if (elder.FirstName == string.Empty || elder.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdElder = _elderrepo.AddElder(elder);

            return Created("elder", createdElder);
        }

        [HttpPut]
        public IActionResult UpdateElder([FromBody] Elder elder)
        {
            if (elder == null)
                return BadRequest();

            if (elder.FirstName == string.Empty || elder.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var elderToUpdate = _elderrepo.GetElderById(elder.Id);

            if (elderToUpdate == null)
                return NotFound();

            _elderrepo.UpdateElder(elder);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteElder(int id)
        {
            if (id == 0)
                return BadRequest();

            var elderToDelete = _elderrepo.GetElderById(id);
            if (elderToDelete == null)
                return NotFound();

            _elderrepo.DeleteElder(id);

            return NoContent();//success
        }
    }
}
