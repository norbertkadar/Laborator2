using System;
using System.Collections.Generic;
using System.Linq;
using Laborator2.Models;
using Laborator2.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laborator2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TasksDbContext context;
        public TasksController(TasksDbContext context)
        {
            this.context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<Task> Get([FromQuery]DateTime from, [FromQuery]DateTime to)
        {
            IQueryable<Task> result = context.Tasks;
            if (from == null && to == null)
            {
                return result;
            }
            if (from != null)
            {
                result = result.Where(p => p.Deadline >= from);
            }
            if (to != null)
            {
                result = result.Where(p => p.Deadline <= to);
            }
            return result;

        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = context.Tasks
                .Include(p=>p.Comments)
                .FirstOrDefault(t => t.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        //POST: api/Tasks
        [HttpPost]
        public void Post([FromBody] Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Task task)
        {
            var exists = context.Tasks.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (exists == null)
            {
                context.Tasks.Add(task);
                context.SaveChanges();
                return Ok(task);
            }
            task.Id = id;
            context.Tasks.Update(task);
            context.SaveChanges();
            return Ok(task);
        }

        //Delete: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exists = context.Tasks.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (exists == null)
            {
                return NotFound();
            }
            context.Tasks.Remove(exists);
            context.SaveChanges();
            return Ok();
        }
        
    }
}