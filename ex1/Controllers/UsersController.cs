using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Zxcvbn;
using Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ex1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IuserService service;
        public UsersController(IuserService service)
        {
            this.service = service;
        }
        // GET: api/<Users>
        [HttpGet]
        public async Task<ActionResult<User>> Get([FromQuery] string email, [FromQuery] string password)
        {
          User user= await service.getUserByEmailAndPassword(email, password);
            if(user==null)
                return NoContent();
            return Ok(user);
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get([FromRoute]int id)
        {
            User user = await service.getUserById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        // POST api/<Users>
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] User user)
        {
            
            User newUser = await service.addUser(user);
            if (newUser == null)
            {
                return null;
            }
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);

        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User value)
        {
            await service.updateUser(id, value);

        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        // POST api/<Users>
        [HttpPost("check")]
        public int Post([FromBody] string password)
        {
            return service.checkPassword(password);
        }
    }
}
