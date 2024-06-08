using Exceptions;
using Library.DTOs;
using Library.Models;
using LibraryASM.Repositories;

namespace LibraryASM.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResponseBookDTO> AddBookAsync(RequestBookDTO requestBookDTO)
        {
            var book = new Book
            {
                BookTitle = requestBookDTO.BookTitle,
                BookAuthor = requestBookDTO.BookAuthor,
                BookDescription = requestBookDTO.BookDescription,
                BookQuantity = requestBookDTO.BookQuantity,
                CategoryId = requestBookDTO.CategoryId
            };

            _bookRepository.AddBookAsync(book);
            return new ResponseBookDTO
            {
                BookId = book.BookId,
                BookTitle = book.BookTitle,
                BookAuthor = book.BookAuthor,
                BookDescription = book.BookDescription,
                BookQuantity = book.BookQuantity,
                CategoryId = book.CategoryId
            };
        }

        public async Task DeleteBookAsync(Guid bookId)
        {
            var currentBook = await _bookRepository.GetBookByIdAsync(bookId);
            if(currentBook == null)
            {
                throw new NotFoundException();
            }
            await _bookRepository.DeleteBookAsync(bookId);
        }

        public async Task<IEnumerable<ResponseBookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            if (books == null)
            {
                throw new NotFoundException();
            }
            var responseBook = books.Select(b => new ResponseBookDTO
            {
                BookId = b.BookId,
                BookTitle = b.BookTitle,
                BookAuthor = b.BookAuthor,
                BookDescription = b.BookDescription,
                BookQuantity = b.BookQuantity,
                CategoryId = b.CategoryId
            }).ToList();
            return responseBook;
        }

        public async Task<ResponseBookDTO> GetBookByIdAsync(Guid bookId)
        {
            var currentBook = await _bookRepository.GetBookByIdAsync(bookId);
            if (currentBook == null)
            {
                throw new NotFoundException();
            }
            return new ResponseBookDTO
            {
                BookId = currentBook.BookId,
                BookTitle = currentBook.BookTitle,
                BookAuthor = currentBook.BookAuthor,
                BookDescription = currentBook.BookDescription,
                BookQuantity = currentBook.BookQuantity,
                CategoryId = currentBook.CategoryId
            };
        }

        public async Task UpdateBookAsync(Guid bookId, RequestBookDTO requestBookDTO)
        {
            var currentBook = await _bookRepository.GetBookByIdAsync(bookId);
            if (currentBook == null)
            {
                throw new NotFoundException();
            }
            currentBook.BookTitle = requestBookDTO.BookTitle;
            currentBook.BookAuthor = requestBookDTO.BookAuthor;
            currentBook.BookDescription = requestBookDTO.BookDescription;
            currentBook.BookQuantity = requestBookDTO.BookQuantity;
            currentBook.CategoryId = requestBookDTO.CategoryId;
            await _bookRepository.UpdateBookAsync(bookId, currentBook);
        }
    }
}
