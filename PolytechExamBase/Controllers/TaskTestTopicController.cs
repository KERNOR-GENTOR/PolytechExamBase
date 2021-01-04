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
    public class TaskTestTopicController : ControllerBase
    {

        private readonly PolytechExamTestContext _context;

        public TaskTestTopicController(PolytechExamTestContext context)
        {
            _context = context;
        }

        // GET: api/TaskTestTopic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskTestTopic>>> GetTaskTestTopic()
        {
            return await _context.TaskTestTopic.ToListAsync();
        }

        // GET: api/TaskTestTopic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskTestTopic>> GetTaskTestTopic(int id)
        {
            var task_test_topic = await _context.TaskTestTopic.FindAsync(id);

            if (task_test_topic == null)
            {
                return NotFound();
            }

            return task_test_topic;
        }

        // PUT: api/TaskTestTopic/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskTestTopic(int id, TaskTestTopic task_test_topic)
        {
            //if (id != task_test_topic.TaskTestTopicId)
            //{
            //    return BadRequest();
            //}

            task_test_topic.TaskTestTopicId = id;

            _context.Entry(task_test_topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTestTopicExists(id))
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

        // POST: api/TaskTestTopic
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TaskTestTopic>> PostTaskTestTopic(TaskTestTopic task_test_topic)
        {
            _context.TaskTestTopic.Add(task_test_topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskTestTopic", new { id = task_test_topic.TaskTestTopicId }, task_test_topic);
        }

        // DELETE: api/TaskTestTopic/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskTestTopic>> DeleteTaskTestTopic(int id)
        {
            var task_test_topic = await _context.TaskTestTopic.FindAsync(id);
            if (task_test_topic == null)
            {
                return NotFound();
            }

            _context.TaskTestTopic.Remove(task_test_topic);
            await _context.SaveChangesAsync();

            return task_test_topic;
        }

        private bool TaskTestTopicExists(int id)
        {
            return _context.TaskTestTopic.Any(e => e.TaskTestTopicId == id);
        }
    }
}
