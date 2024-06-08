using Library.DTOs;
using LibraryASM.Repositories;

namespace LibraryASM.Services
{
    public class RequestDetailService : IRequestDetailService
    {
        private readonly IRequestDetailRepository _requestDetailRepository;

        public RequestDetailService(IRequestDetailRepository requestDetailRepository)
        {
            _requestDetailRepository = requestDetailRepository;
        }

        public async Task Add(Guid requestId, List<Guid> bookIds)
        {
            if (bookIds == null)
            {
                throw new ArgumentException("Book IDs cannot be null or empty", nameof(bookIds));
            }
            await _requestDetailRepository.AddRequestDetailAsync(requestId, bookIds);
        }

        public async Task<IEnumerable<ResponseBookDTO>> GetBooksByRequest(Guid requestId)
        {
            var books = await _requestDetailRepository.GetBooksByRequest(requestId);

            var bookDTOs = books.Select(book => new ResponseBookDTO
            {
                BookId = book.BookId,
                BookTitle = book.BookTitle,
                BookAuthor = book.BookAuthor,
                BookDescription = book.BookDescription,
                BookQuantity = book.BookQuantity
            });

            return bookDTOs;
        }
    }
}
