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
    public class TestTopicController : ControllerBase
    {

        private readonly PolytechExamTestContext _context;

        public TestTopicController(PolytechExamTestContext context)
        {
            _context = context;
        }

        // GET: api/TestTopic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestTopic>>> GetTestTopic()
        {
            return await _context.TestTopic.ToListAsync();
        }

        // GET: api/TestTopic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestTopic>> GetTestTopic(int id)
        {
            var test_topic = await _context.TestTopic.FindAsync(id);

            if (test_topic == null)
            {
                return NotFound();
            }

            return test_topic;
        }

        // PUT: api/TestTopic/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestTopic(int id, TestTopic test_topic)
        {
            //if (id != test_topic.TestTopicId)
            //{
            //    return BadRequest();
            //}

            test_topic.TopicId = id;

            _context.Entry(test_topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestTopicExists(id))
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

        // POST: api/TestTopic
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TestTopic>> PostTestTopic(TestTopic test_topic)
        {
            _context.TestTopic.Add(test_topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestTopic", new { id = test_topic.TopicId }, test_topic);
        }

        // DELETE: api/TestTopic/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestTopic>> DeleteTestTopic(int id)
        {
            var test_topic = await _context.TestTopic.FindAsync(id);
            if (test_topic == null)
            {
                return NotFound();
            }

            _context.TestTopic.Remove(test_topic);
            await _context.SaveChangesAsync();

            return test_topic;
        }

        private bool TestTopicExists(int id)
        {
            return _context.TestTopic.Any(e => e.TopicId == id);
        }
    }
}
