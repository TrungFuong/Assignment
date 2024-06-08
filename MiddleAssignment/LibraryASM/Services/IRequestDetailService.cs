
using Library.DTOs;
using Library.Models;

namespace LibraryASM.Services
{
    public interface IRequestDetailService
    {
        Task<IEnumerable<ResponseBookDTO>> GetBooksByRequest(Guid requestId);
        Task Add(Guid requestId, List<Guid> bookIds);
    }
}
