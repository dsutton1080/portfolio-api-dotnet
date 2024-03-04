using Microsoft.AspNetCore.Mvc;
using portfolio_api_dotnet.Models;
using Project.Services;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly EFService _service;
        public SectionController(EFService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Section>> Get()
        {
            return _service.QueryEntities<Section>(s => true);
        }

        [HttpGet("{id}")]
        public ActionResult<Section> Get(int id)
        {
            var section = _service.QueryEntities<Section>(s => s.Id == id).FirstOrDefault();

            if (section == null)
            {
                return NotFound();
            }
            return section;
        }

        [HttpPost]
        public ActionResult<Section> Post(Section section)
        {
            _service.AddEntity(section);
            return CreatedAtAction(nameof(Get), new { id = section.Id }, section);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Section section)
        {
            if (id != section.Id)
            {
                return BadRequest();
            }

            _service.UpdateEntity(section);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var section = _service.QueryEntities<Section>(s => s.Id == id).FirstOrDefault();

            if (section == null)
            {
                return NotFound();
            }

            _service.DeleteEntity(section);
            return NoContent();
        }
    }
}