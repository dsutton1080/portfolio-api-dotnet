using Microsoft.AspNetCore.Mvc;
using portfolio_api_dotnet.Models;
using Project.Services;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly EFService _service;
        public ExperienceController(EFService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Experience>> Get()
        {
            return _service.QueryEntities<Experience>(e => true);
        }

        [HttpGet("{id}")]
        public ActionResult<Experience> Get(int id)
        {
            var experience = _service.QueryEntities<Experience>(e => e.Id == id).FirstOrDefault();

            if (experience == null)
            {
                return NotFound();
            }
            return experience;
        }

        [HttpPost]
        public ActionResult<Experience> Post(Experience experience)
        {
            _service.AddEntity(experience);
            return CreatedAtAction(nameof(Get), new { id = experience.Id }, experience);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Experience experience)
        {
            if (id != experience.Id)
            {
                return BadRequest();
            }

            _service.UpdateEntity(experience);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var experience = _service.QueryEntities<Experience>(e => e.Id == id).FirstOrDefault();

            if (experience == null)
            {
                return NotFound();
            }

            _service.DeleteEntity(experience);
            return NoContent();
        }
    }
}