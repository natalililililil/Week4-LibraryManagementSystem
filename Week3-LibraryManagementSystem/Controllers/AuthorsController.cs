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
        public async Task<IActionResult> Create([FromBody] AuthorDto dto)
        {
            var author = new Author
            {
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth
            };

            var created = await _authorRepository.CreateAsync(author);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AuthorDto dto)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return NotFound();

            author.Name = dto.Name;
            author.DateOfBirth = dto.DateOfBirth;

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
