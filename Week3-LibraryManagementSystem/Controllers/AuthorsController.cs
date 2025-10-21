using Microsoft.AspNetCore.Mvc;
using Week3_LibraryManagementSystem.Models;
using Week3_LibraryManagementSystem.Repository;

namespace Week3_LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_authorRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null) 
                return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Author author) 
        {
            var result = _authorRepository.Create(author);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Author author)
        {
            if (id != author.Id)
                return BadRequest("Id в URL и теле запроса должны совпадать");

            var updated = _authorRepository.Update(author);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var author = _authorRepository.Delete(id);

            if (!author)
                return NotFound();

            return NoContent();
        }
    }
}
