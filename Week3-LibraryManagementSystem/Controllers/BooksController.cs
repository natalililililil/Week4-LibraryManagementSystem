using Microsoft.AspNetCore.Mvc;
using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;

namespace Week3_LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepo)
        {
            _bookRepository = bookRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null) 
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                PublishedYear = dto.PublishedYear,
                AuthorId = dto.AuthorId
            };

            var created = await _bookRepository.CreateAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();

            book.Title = dto.Title;
            book.PublishedYear = dto.PublishedYear;
            book.AuthorId = dto.AuthorId;

            var updated = await _bookRepository.UpdateAsync(book);

            if (!updated) 
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _bookRepository.DeleteAsync(id);

            if (!deleted) 
                return NotFound();
            return NoContent();
        }
    }
}
