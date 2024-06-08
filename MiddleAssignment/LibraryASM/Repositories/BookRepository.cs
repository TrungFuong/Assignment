using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryASM.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryASMDBContext _context;
        public BookRepository(LibraryASMDBContext context)
        {
            _context = context;
        }

        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Guid bookId)
        {
            var currentBook = await GetBookByIdAsync(bookId);
            if (currentBook != null)
            {
                _context.Books.Remove(currentBook);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
            //var book = new Book();
            //var skipNumber = (book.PageNumber - 1) * book.PageSize;
            //return books.Skip(skipNumber).Take(book.PageSize);
        }

        public async Task<Book> GetBookByIdAsync(Guid bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }

        public async Task UpdateBookAsync(Guid bookId, Book book)
        {
            var currentBook = await GetBookByIdAsync(bookId);
            if (currentBook != null)
            {
                //currentBook.BookTitle = book.BookTitle;
                //currentBook.BookDescription = book.BookDescription;
                //currentBook.BookQuantity = book.BookQuantity;
                //currentBook.CategoryId = book.CategoryId;
                //_context.SaveChangesAsync();
                //Em giờ đang ở một cương vị mới, từ nông dân lên làm thương lái

                _context.Update(book);
                _context.SaveChangesAsync();
            }
        }
    }
}
