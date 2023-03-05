using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNetCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ASPNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FFAContext _context;
        public UsersController(FFAContext context)
        {
            _context = context;
            if (_context.User.Count() == 0)
            {
                _context.User.Add(new User
                {
                    Login = "CoolGuy"
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.User;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await  _context.User.SingleOrDefaultAsync(u => u.Id == id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }
    
}
