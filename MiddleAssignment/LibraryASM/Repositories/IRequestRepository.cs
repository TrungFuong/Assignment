using Azure.Core;
using Library.Models;
using LibraryASM.DTOs;

namespace LibraryASM.Repositories
{
    public interface IRequestRepository
    {
        Task<IEnumerable<BookBorrowingRequest>> GetAllRequestsAsync();
        Task<BookBorrowingRequest> GetRequestByIdAsync(Guid requestId);
        Task AddRequestAsync(BookBorrowingRequest request);
        Task DeleteRequestAsync(Guid requestId);
        Task<List<BookBorrowingRequest>> GetRequestsByUserAsync(Guid userId);
        Task UpdateRequestStatus(Guid requestId, BookBorrowingRequest request);
    }
}
