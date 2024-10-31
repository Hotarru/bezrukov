using kt7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace kt7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return student;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            students.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            var index = students.FindIndex(s => s.Id == id);
            if (index == -1) return NotFound();
            students[index] = student;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = students.FindIndex(s => s.Id == id);
            if (index == -1) return NotFound();
            students.RemoveAt(index);
            return NoContent();
        }
    }
}
