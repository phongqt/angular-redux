using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Controllers
{
  [Route("api/todo")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly TodoContext _context;

    public TodoController(TodoContext context)
    {
      _context = context;
    }
    // GET: api/Todo
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        return Ok(await _context.Todo.ToListAsync());
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    // GET: api/Todo/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        return Ok(_context.Todo.FindAsync(id));
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    // POST: api/Todo
    [HttpPost]
    public async Task<IActionResult> Post(Models.Todo todo)
    {
      try
      {
        _context.Add(todo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    // PUT: api/Todo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Models.Todo todo)
    {
      var model = await _context.Todo.FindAsync(id);
      try
      {
        _context.Update(todo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
      try
      {
        var todo = await _context.Todo.FindAsync(id);
        _context.Todo.Remove(todo);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
  }
}
