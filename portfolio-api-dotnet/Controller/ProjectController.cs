using Microsoft.AspNetCore.Mvc;
using portfolio_api_dotnet.Models;
using Project.Services;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly EFService _service;
        public ProjectController(EFService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ProjectClass>> Get()
        {
            return _service.QueryEntities<ProjectClass>(p => true);
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectClass> Get(int id)
        {
            var project = _service.QueryEntities<ProjectClass>(p => p.Id == id).FirstOrDefault();

            if (project == null)
            {
                return NotFound();
            }
            return project;
        }

        [HttpPost]
        public ActionResult<ProjectClass> Post(ProjectClass project)
        {
            _service.AddEntity(project);
            return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProjectClass project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _service.UpdateEntity(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _service.QueryEntities<ProjectClass>(p => p.Id == id).FirstOrDefault();

            if (project == null)
            {
                return NotFound();
            }

            _service.DeleteEntity(project);
            return NoContent();
        }
    }
}