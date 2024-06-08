using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryASM.Repositories
{
    public class RequestDetailRepository : IRequestDetailRepository
    {
        private readonly LibraryASMDBContext _context;
        public RequestDetailRepository(LibraryASMDBContext context)
        {
            _context = context;
        }

        public async Task AddRequestDetailAsync(Guid requestId, List<Guid> bookIds)
        {
            var requestDetails = bookIds.Select(bookId => new BookBorrowingRequestDetail
            {
                RequestId = requestId,
                BookId = bookId
            }).ToList();

            await _context.BookBorrowingRequestDetails.AddRangeAsync(requestDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetBooksByRequest(Guid requestId)
        {
            return await _context.BookBorrowingRequestDetails
                .Where(bbrd => bbrd.RequestId == requestId)
                .Select(bbrd => bbrd.Book)
                .ToListAsync();
        }
    }
}
