using Microsoft.AspNetCore.Mvc;
using Week3_LibraryManagementSystem.Models;
using Week3_LibraryManagementSystem.Repository;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepository.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null) 
                return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            var created = await _authorRepository.CreateAsync(author);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Author author)
        {
            if (id != author.Id) 
                return BadRequest("Id в URL и теле запроса должны совпадать");

            var updated = await _authorRepository.UpdateAsync(author);

            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _authorRepository.DeleteAsync(id);

            if (!deleted) 
                return NotFound();
            return NoContent();
        }
    }
}
