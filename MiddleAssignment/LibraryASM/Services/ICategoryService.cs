using Library.DTOs;
using Library.Models;

namespace LibraryASM.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<ResponseCategoryDTO>> GetAllCategoriesAsync();
        Task<ResponseCategoryDTO> GetCategoryById(int categoryId);
        Task<ResponseCategoryDTO> AddCategoryAsync(RequestCategoryDTO requestCategoryDTO);
        Task DeleteCategoryAsync(int categoryId);
        Task UpdateCategoryAsync(int categoryId, RequestCategoryDTO requestCategoryDTO);
        Task<IEnumerable<ResponseBookDTO>> GetBooksByCategory(int categoryId, int pageNumber, int pageSize);
    }
}
