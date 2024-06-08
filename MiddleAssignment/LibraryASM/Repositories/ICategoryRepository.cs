using Library.Models;
using System.Collections.Generic;

namespace LibraryASM.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
        Task UpdateCategoryAsync(int categoryId, Category category);
        Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId, int pageNumber, int pageSize);
    }
}
