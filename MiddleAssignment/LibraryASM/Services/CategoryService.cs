using Exceptions;
using Library.DTOs;
using Library.Models;
using LibraryASM.Repositories;

namespace LibraryASM.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger) // Inject logger
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<ResponseCategoryDTO> AddCategoryAsync(RequestCategoryDTO requestCategoryDTO)
        {
            var category = new Category
            {
                CategoryName = requestCategoryDTO.CategoryName,
            };
            await _categoryRepository.AddCategoryAsync(category);

            return new ResponseCategoryDTO
            {
                CategoryName = category.CategoryName
            };
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var currentCategory = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (currentCategory == null)
            {
                throw new NotFoundException();
            }
            await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<ResponseCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            if (categories == null)
            {
                throw new NotFoundException();
            }
            var responseCategories = categories.Select(c => new ResponseCategoryDTO
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();
            _logger.LogInformation("Response Categories: {@Categories}", responseCategories); // Change here
            return responseCategories;
        }

        public async Task<ResponseCategoryDTO> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundException();
            }
            return new ResponseCategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public async Task UpdateCategoryAsync(int categoryId, RequestCategoryDTO requestCategoryDTO)
        {
            var currentCategory = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (currentCategory == null)
            {
                throw new NotFoundException();
            }
            currentCategory.CategoryName = requestCategoryDTO.CategoryName;
            await _categoryRepository.UpdateCategoryAsync(categoryId, currentCategory);
        }

        public async Task<IEnumerable<ResponseBookDTO>> GetBooksByCategory(int categoryId, int pageNumber = 1, int pageSize = 20)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundException();
            }

            var books = await _categoryRepository.GetBooksByCategoryAsync(categoryId, pageNumber, pageSize);
            if (books == null)
            {
                throw new NotFoundException();
            }

            var responseBooks = books.Select(b => new ResponseBookDTO
            {
                BookId = b.BookId,
                BookTitle = b.BookTitle,
                BookAuthor = b.BookAuthor,
                BookDescription = b.BookDescription,
                BookQuantity = b.BookQuantity
            });

            return responseBooks;
        }
    }
}
