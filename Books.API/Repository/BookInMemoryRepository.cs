using Books.API.Models;
using System.Numerics;

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
            _bookList.Add(new Book { Name = "Atomic Habits", Author = "Jerman Housell", Description = "Improving the daily habits", Amount = 500 });
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

        public Book GetCostliestBook()
        {

            var costlyBook = new Book();
            costlyBook.Amount = -1;
            foreach (var book in _bookList)
            {
                if (book.Amount > costlyBook.Amount) { costlyBook = book; }
            }
            return costlyBook;
        }

        public bool DeleteAllBooks()
        {
            if (_bookList.Count > 0)
            {
                _bookList.Clear();
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
            if(_bookList.Count > 0) return _bookList;
            return null;

        }

        public Book GetBookById(Guid id)
        {
            var book = _bookList.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public IEnumerable<Book> GetCostlyAndCheapBooks()
        {
            List<Book> books = new List<Book>();
            Book minBook = _bookList.First();
            foreach (var book in _bookList)
            {
                if (book.Amount < minBook.Amount)
                {
                    minBook = book;
                }
            }
            books.Add(minBook);
            books.Add(GetCostliestBook());
            if (books.Count == 0)
            {
                return null;
            }
            return books;
        }

        public IEnumerable<Book> GetBooksStartingWithA()
        {
            List<Book> books = new List<Book>();
            foreach(var book in _bookList)
            {
                var bookName=book.Name.ToLower();
                if (bookName.StartsWith('a'))
                {
                    books.Add(book);
                }
            }
            if (books.Count == 0) return null;
            return books;
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

        public IEnumerable<Book> GetBooksBetweenMaxAndMinAmount(double maxAmount, double minAmount)
        {
            List<Book> books= new List<Book>();
            foreach (var book in _bookList)
            { 
                if (book.Amount < maxAmount && book.Amount > minAmount)
                {
                    books.Add(book);
                }
            }
            if (books.Count == 0) return null;
            return books;

        }
    }
}
