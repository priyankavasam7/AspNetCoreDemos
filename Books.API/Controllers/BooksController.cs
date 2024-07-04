using Books.API.Models;
using Books.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        { 
            var books=_bookRepository.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetBook(Guid id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound($"Requested Book with id = {id} is Not Found");
        }
        [HttpPost]
        public IActionResult AddBook([FromBody]Book book)
        {
            var isBookAdded=_bookRepository.AddBook(book);
            if (isBookAdded)
            {
                return Ok(book);
            }
            return StatusCode(500);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            var isBookDeleted = _bookRepository.DeleteBook(id);
            if (isBookDeleted)
            {
                return Ok($"The Book with Id = {id} is deleted Successfully!!");
            }
            return NotFound($"The Book with Id = {id} is Not Found");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id,Book book)
        {
            var updateBook=_bookRepository.UpdateBook(id, book);
            if(updateBook != null)
            {
                return Ok(updateBook);
            }
            return NotFound($"The Book with Id = {id} is Not Found");
        }
    }
}
