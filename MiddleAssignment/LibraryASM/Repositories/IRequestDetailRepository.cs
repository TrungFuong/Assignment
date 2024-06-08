using Library.Models;

namespace LibraryASM.Repositories
{
    public interface IRequestDetailRepository
    {
        Task<List<Book>> GetBooksByRequest(Guid requestId);
        Task AddRequestDetailAsync(Guid requestId, List<Guid> bookIds);
    }
}
