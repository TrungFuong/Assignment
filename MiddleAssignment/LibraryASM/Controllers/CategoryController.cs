using Library.DTOs;
using LibraryASM.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryASM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategories(int PageNumber, int PageSize)
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, RequestCategoryDTO requestCategoryDTO)
        {
            await _categoryService.UpdateCategoryAsync(categoryId, requestCategoryDTO);
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCategory(RequestCategoryDTO requestCategoryDTO)
        {
            var createdCategory = await _categoryService.AddCategoryAsync(requestCategoryDTO);
            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = createdCategory.CategoryId }, createdCategory);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryService.DeleteCategoryAsync(categoryId);
            return NoContent();
        }

        //GET BOOKS IN A CATEGORY
        [HttpGet("{categoryId}/books")]
        public async Task<IActionResult> GetBooksByCategory(int categoryId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var books = await _categoryService.GetBooksByCategory(categoryId, pageNumber, pageSize);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);




        }
    }
}