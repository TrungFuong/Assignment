using Library.DTOs;
using Library.Models;
using LibraryASM.DTOs;

namespace LibraryASM.Services
{
    public interface IRequestService
    {
        Task<List<BookBorrowingResponseDTO>> GetRequestsByUserAsync(Guid userId);
        Task<BookBorrowingResponseDTO> GetRequestByIdAsync(Guid requestId);
        Task<BookBorrowingResponseDTO> AddRequestAsync(BookBorrowingResquestDTO RequestDTO);
        Task DeleteRequestAsync(Guid requestId);
        Task UpdateRequestStatus(Guid requestId, BookBorrowingResquestDTO resquestDTO);
    }
}
