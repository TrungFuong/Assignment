using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryASM.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LibraryASMDBContext _context;
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(LibraryASMDBContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task AddCategoryAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var currentCategory = await GetCategoryByIdAsync(categoryId);
            if (currentCategory != null)
            {
                _context.Categories.Remove(currentCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            _logger.LogInformation("Categories retrieved: {Categories}", categories); // Log categories
            //var category = new Category();
            //var skipNumber = (category.PageNumber - 1) * category.PageSize;
            //return categories.Skip(skipNumber).Take(category.PageSize);
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task UpdateCategoryAsync(int categoryId, Category category)
        {
            var currentCategory = await GetCategoryByIdAsync(categoryId);
            if (currentCategory != null)
            {
                //currentCategory.CategoryName = category.CategoryName;
                //Mới khám phá ra hàm Update

                _context.Update(currentCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId, int pageNumber, int pageSize)
        {
            return await _context.Books
                .Where(b => b.CategoryId == categoryId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
