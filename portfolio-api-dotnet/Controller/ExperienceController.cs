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
            var experienceRecord = _service.QueryEntities<Experience>(e => e.Id == id).FirstOrDefault();

            if (experienceRecord == null)
            {
                return NotFound();
            }
            experienceRecord.Title = experience.Title;
            experienceRecord.Content = experience.Content;
            experienceRecord.Date = experience.Date;

            _service.UpdateEntity(experienceRecord);
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