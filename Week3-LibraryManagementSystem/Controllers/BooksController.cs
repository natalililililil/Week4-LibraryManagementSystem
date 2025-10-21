using Microsoft.AspNetCore.Mvc;
using Week3_LibraryManagementSystem.Models;
using Week3_LibraryManagementSystem.Repository;

namespace Week3_LibraryManagementSystem.Controllers
{
    namespace Week3_LibraryManagementSystem.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class BooksController : ControllerBase
        {
            private readonly IBookRepository _bookRepository;

            public BooksController(IBookRepository bookRepo, IAuthorRepository authorRepo)
            {
                _bookRepository = bookRepo;
            }

            [HttpGet]
            public IActionResult GetAll() => Ok(_bookRepository.GetAll());

            [HttpGet("{id}")]
            public IActionResult GetById(Guid id)
            {
                var book = _bookRepository.GetById(id);
                if (book == null) 
                    return NotFound();
                return Ok(book);
            }

            [HttpPost]
            public IActionResult Create([FromBody] Book book)
            {
                var created = _bookRepository.Create(book);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }

            [HttpPut("{id}")]
            public IActionResult Update(Guid id, [FromBody] Book book)
            {
                if (id != book.Id)
                    return BadRequest("Id в URL и теле запроса должны совпадать");

                var updated = _bookRepository.Update(book);
                if (!updated) return NotFound();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(Guid id)
            {
                var deleted = _bookRepository.Delete(id);
                if (!deleted) 
                    return NotFound();
                return NoContent();
            }
        }
    }
}
