using Books.API.Models;

namespace Books.API.Repository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBookById(Guid id);
        public bool AddBook(Book book);
        public Book UpdateBook(Guid id,Book book);
        public bool DeleteBook(Guid id);
        public bool DeleteAllBooks();
        public Book GetCostliestBook();
        public IEnumerable<Book> GetCostlyAndCheapBooks();
        public IEnumerable<Book> GetBooksStartingWithA();
        public IEnumerable <Book> GetBooksBetweenMaxAndMinAmount(double maxAmount, double minAmount);

    }
}
