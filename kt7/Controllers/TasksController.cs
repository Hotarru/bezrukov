using kt7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace kt7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> tasks = new List<TaskItem>();

        [HttpGet]
        public IEnumerable<TaskItem> Get([FromQuery] string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return tasks;
            }

            return tasks.Where(t => t.Status.Equals(status, System.StringComparison.OrdinalIgnoreCase));
        }

        [HttpGet("{id}")]
        public ActionResult<TaskItem> Get(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            return task;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskItem task)
        {
            task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            tasks.Add(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TaskItem task)
        {
            var index = tasks.FindIndex(t => t.Id == id);
            if (index == -1) return NotFound();
            tasks[index] = task;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = tasks.FindIndex(t => t.Id == id);
            if (index == -1) return NotFound();
            tasks.RemoveAt(index);
            return NoContent();
        }
    }
}
