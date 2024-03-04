using Microsoft.AspNetCore.Mvc;
using portfolio_api_dotnet.Models;
using Project.Services;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly EFService _service;
        public UserController(EFService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _service.QueryEntities<User>(u => true);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _service.QueryEntities<User>(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            _service.AddEntity(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(User user)
        {
            var userFromDb = _service.QueryEntities<User>(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (userFromDb == null)
            {
                return NotFound();
            }
            return userFromDb;
        }

        [HttpPost("signup")]
        public ActionResult<User> Signup(User user)
        {
            var userFromDb = _service.QueryEntities<User>(u => u.Email == user.Email).FirstOrDefault();

            if (userFromDb != null)
            {
                return BadRequest();
            }
            _service.AddEntity(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _service.UpdateEntity(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _service.QueryEntities<User>(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }
            _service.DeleteEntity(user);
            return NoContent();
        }
    }
}