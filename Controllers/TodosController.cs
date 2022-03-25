using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internsfcsamericaTodoList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace internsfcsamericaTodoList.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly internsTodoContext _context;

        public TodosController(internsTodoContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<internsTodo>>> GetTodos()
        {
            return await _context.internsTodo.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<internsTodo>> GetTodo(int id)
        {
            var todo = await _context.internsTodo.FindAsync(id);
            if(todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<internsTodo>> PostTodo(internsTodo todo)
        {
            _context.internsTodo.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<internsTodo>> PutTodo(int id, internsTodo todo)
        {
            if ( id != todo.Id)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return todo;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var todo = await _context.internsTodo.FindAsync(id);
            if(todo == null)
            {
                return NotFound();
            }

            _context.internsTodo.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoExists(int id)
        {
            return _context.internsTodo.Any(e => e.Id == id);
        }
    }
}
