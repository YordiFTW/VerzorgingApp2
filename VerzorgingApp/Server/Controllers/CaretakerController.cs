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
    public class CaretakerController : ControllerBase
    {
        private readonly ICaretakerRepo _caretakerrepo;

        public CaretakerController(ICaretakerRepo caretakerRepository)
        {
            _caretakerrepo = caretakerRepository;
        }

        [HttpGet]
        public IActionResult GetAllCaretakers()
        {
            return Ok(_caretakerrepo.GetAllCaretakers());
        }

        [HttpGet("{id}")]
        public IActionResult GetCaretakerById(int id)
        {
            return Ok(_caretakerrepo.GetCaretakerById(id));
        }

        [HttpPost]
        public IActionResult CreateCaretaker([FromBody] Caretaker caretaker)
        {
            if (caretaker == null)
                return BadRequest();

            if (caretaker.FirstName == string.Empty || caretaker.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCaretaker = _caretakerrepo.AddCaretaker(caretaker);

            return Created("caretaker", createdCaretaker);
        }

        [HttpPut]
        public IActionResult UpdateCaretaker([FromBody] Caretaker caretaker)
        {
            if (caretaker == null)
                return BadRequest();

            if (caretaker.FirstName == string.Empty || caretaker.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var caretakerToUpdate = _caretakerrepo.GetCaretakerById(caretaker.Id);

            if (caretakerToUpdate == null)
                return NotFound();

            _caretakerrepo.UpdateCaretaker(caretaker);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCaretaker(int id)
        {
            if (id == 0)
                return BadRequest();

            var caretakerToDelete = _caretakerrepo.GetCaretakerById(id);
            if (caretakerToDelete == null)
                return NotFound();

            _caretakerrepo.DeleteCaretaker(id);

            return NoContent();//success
        }
    }
}
