using Library.Models;

namespace LibraryASM.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(Guid bookId);
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(Guid bookId);
        Task UpdateBookAsync(Guid bookId, Book book);
    }
}
