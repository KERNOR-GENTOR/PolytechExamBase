using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolytechExamBase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PolytechExamBase.Controllers
{
    [EnableCors("myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class DbuserController : ControllerBase
    {

        private readonly PolytechExamTestContext _context;

        public DbuserController(PolytechExamTestContext context)
        {
            _context = context;
        }

        // GET: api/Dbuser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dbuser>>> GetUser()
        {
            return await _context.Dbuser.ToListAsync();
        }

        // GET: api/Dbuser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dbuser>> GetUser(int id)
        {
            var user = await _context.Dbuser.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Dbuser/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Dbuser user)
        {
            //if (id != user.IdUser)
            //{
            //    return BadRequest();
            //}

            user.UserId = id;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dbuser
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dbuser>> PostUser(Dbuser user)
        {
            _context.Dbuser.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Dbuser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dbuser>> DeleteUser(int id)
        {
            var user = await _context.Dbuser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Dbuser.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Dbuser.Any(e => e.UserId == id);
        }
    }
}
