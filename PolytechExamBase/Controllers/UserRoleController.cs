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
    public class UserRoleController : ControllerBase
    {

        private readonly PolytechExamTestContext _context;

        public UserRoleController(PolytechExamTestContext context)
        {
            _context = context;
        }

        // GET: api/UserRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserRole()
        {
            return await _context.UserRole.ToListAsync();
        }

        // GET: api/UserRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetUserRole(int id)
        {
            var user_role = await _context.UserRole.FindAsync(id);

            if (user_role == null)
            {
                return NotFound();
            }

            return user_role;
        }

        // PUT: api/UserRole/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRole(int id, UserRole user_role)
        {
            //if (id != user_role.UserRoleId)
            //{
            //    return BadRequest();
            //}

            user_role.UserRoleId = id;

            _context.Entry(user_role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleExists(id))
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

        // POST: api/UserRole
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserRole>> PostUserRole(UserRole user_role)
        {
            _context.UserRole.Add(user_role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRole", new { id = user_role.UserRoleId }, user_role);
        }

        // DELETE: api/UserRole/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRole>> DeleteUserRole(int id)
        {
            var user_role = await _context.UserRole.FindAsync(id);
            if (user_role == null)
            {
                return NotFound();
            }

            _context.UserRole.Remove(user_role);
            await _context.SaveChangesAsync();

            return user_role;
        }

        private bool UserRoleExists(int id)
        {
            return _context.UserRole.Any(e => e.UserRoleId == id);
        }
    }
}
