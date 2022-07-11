using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _service;

        public StudentsController(IStudentRepository service)
        {
            _service = service;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            var students = _service.Get();
            return Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _service.Get(id);
            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            _service.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingStudent = _service.Get(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            _service.Update(id, student);
            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingStudent = _service.Get(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            _service.Remove(id);
            return Ok($"Student with Id = {id} deleted");
        }
    }
}
