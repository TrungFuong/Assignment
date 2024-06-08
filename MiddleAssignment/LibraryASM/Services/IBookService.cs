using Library.DTOs;

namespace LibraryASM.Services
{
    public interface IBookService
    {
        Task<IEnumerable<ResponseBookDTO>> GetAllBooksAsync();
        Task<ResponseBookDTO> GetBookByIdAsync(Guid bookId);
        Task<ResponseBookDTO> AddBookAsync(RequestBookDTO requestBookDTO);
        Task DeleteBookAsync(Guid bookId);
        Task UpdateBookAsync(Guid bookId, RequestBookDTO requestUserDTO);
    }
}