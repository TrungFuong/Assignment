using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryASM.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly LibraryASMDBContext _context;
        public RequestRepository(LibraryASMDBContext context)
        {
            _context = context;
        }

        public async Task AddRequestAsync(BookBorrowingRequest request)
        {
            _context.AddAsync(request);
        }

        public async Task DeleteRequestAsync(Guid requestId)
        {
            var currentRequest = await _context.BookBorrowingRequests.FindAsync(requestId);
            if (currentRequest != null)
            {
                _context.BookBorrowingRequests.Remove(currentRequest);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<BookBorrowingRequest>> GetAllRequestsAsync()
        {
            return await _context.BookBorrowingRequests.ToListAsync();
        }

        public async Task<BookBorrowingRequest> GetRequestByIdAsync(Guid requestId)
        {
            return await _context.BookBorrowingRequests.FindAsync(requestId);
        }

        public async Task<List<BookBorrowingRequest>> GetRequestsByUserAsync(Guid userId)
        {
            return await _context.BookBorrowingRequests.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task UpdateRequestStatus(Guid requestId, BookBorrowingRequest request)
        {
            var currentRequest = await _context.BookBorrowingRequests.FindAsync(requestId);
            if(currentRequest != null)
            {
                _context.BookBorrowingRequests.Update(request);
            }
        }
    }
}
