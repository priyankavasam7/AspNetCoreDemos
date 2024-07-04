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
            if (books != null)
            {
                return Ok(books);
            }
            return Ok("There are no books Yet!!");
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

        [HttpGet]
        [Route("costlybook")]
        public IActionResult GetCostliestBook()
        {
            var book = _bookRepository.GetCostliestBook();
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound("Books not found!!");
        }
       
        [HttpGet]
        [Route("CostlyAndCheapBooks")]
        public IActionResult GetCostlyAndCheapBooks()
        {
            var books= _bookRepository.GetCostlyAndCheapBooks();
            if(books != null)
            {
                return Ok(books);
            }
            return NotFound("Books Not Found!!");
        }

        [HttpGet]
        [Route("BooksStartingWithA")]
        public IActionResult GetBooksStartingWithA()
        {
            var books=_bookRepository.GetBooksStartingWithA();
            if(books != null)
            {
                return Ok(books);
            }
            return NotFound("Books starting with 'A' are Not Found");
        }

        [HttpGet("{minAmount}:{maxAmount}")]
        public IActionResult GetBooksBetweenMaxAndMinAmount(double maxAmount, double minAmount)
        {
            var books=_bookRepository.GetBooksBetweenMaxAndMinAmount(maxAmount, minAmount);
            if(books != null)
            {
                return Ok(books);
            }
            return NotFound("Books in the requested price range are Not Found!!");
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
        
        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            var AreBooksDeleted= _bookRepository.DeleteAllBooks();
            if (AreBooksDeleted)
            {
                return Ok("All books deleted successfully!!");
            }
            return StatusCode(500);
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
