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
    public class UserPassedTaskController : ControllerBase
    {

        private readonly PolytechExamTestContext _context;

        public UserPassedTaskController(PolytechExamTestContext context)
        {
            _context = context;
        }

        // GET: api/UserPassedTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPassedTask>>> GetUserPassedTask()
        {
            return await _context.UserPassedTask.ToListAsync();
        }

        // GET: api/UserPassedTask/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPassedTask>> GetUserPassedTask(int id)
        {
            var user_passed_task = await _context.UserPassedTask.FindAsync(id);

            if (user_passed_task == null)
            {
                return NotFound();
            }

            return user_passed_task;
        }

        // PUT: api/UserPassedTask/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPassedTask(int id, UserPassedTask user_passed_task)
        {
            //if (id != user_passed_task.UserPassedTaskId)
            //{
            //    return BadRequest();
            //}

            user_passed_task.UserPassedTaskId = id;

            _context.Entry(user_passed_task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPassedTaskExists(id))
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

        // POST: api/UserPassedTask
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserPassedTask>> PostUserPassedTask(UserPassedTask user_passed_task)
        {
            _context.UserPassedTask.Add(user_passed_task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPassedTask", new { id = user_passed_task.UserPassedTaskId }, user_passed_task);
        }

        // DELETE: api/UserPassedTask/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserPassedTask>> DeleteUserPassedTask(int id)
        {
            var user_passed_task = await _context.UserPassedTask.FindAsync(id);
            if (user_passed_task == null)
            {
                return NotFound();
            }

            _context.UserPassedTask.Remove(user_passed_task);
            await _context.SaveChangesAsync();

            return user_passed_task;
        }

        private bool UserPassedTaskExists(int id)
        {
            return _context.UserPassedTask.Any(e => e.UserPassedTaskId == id);
        }
    }
}
