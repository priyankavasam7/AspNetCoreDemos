using Books.API.Models;

namespace Books.API.Repository
{
    public class BookInMemoryRepository : IBookRepository
    {
        public List<Book> _bookList=new List<Book>();
        public BookInMemoryRepository() 
        { 
            _bookList.Add(new Book { Name="Secret", Author="John", Description="About secrecy", Amount=345.80});
            _bookList.Add(new Book { Name = "Start With Why", Author = "Simon Seik", Description = "About startups and leadership skills", Amount = 245 });
            _bookList.Add(new Book { Name = "Rich Dad Poor Dad", Author = "Robert kiosaki", Description = "Financial Education", Amount = 425.60 });  
        }
        public bool AddBook(Book book)
        {
            var isBookExists=_bookList.FirstOrDefault(b=>b.Id==book.Id);
            if (isBookExists == null)
            {
                _bookList.Add(book);
                return true;
            }
            return false;

        }

        public bool DeleteBook(Guid id)
        {
            var existingBook=_bookList.FirstOrDefault(b=> b.Id==id);
            if (existingBook != null)
            {
                _bookList.Remove(existingBook);
                return true;
            }
            return false;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookList;
        }

        public Book GetBookById(Guid id)
        {
            var book = _bookList.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public Book UpdateBook(Guid id, Book book)
        {
            var existingBook= _bookList.FirstOrDefault(b=> b.Id==id);
            if (existingBook != null)
            {
                existingBook.Name = book.Name;
                existingBook.Author = book.Author;
                existingBook.Description = book.Description;
                existingBook.Amount = book.Amount;
                return existingBook;
            }
            return null;
        }
    }
}
