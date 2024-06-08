using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using LibraryASM;
using LibraryASM.Services;
using Library.DTOs;

namespace LibraryASM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(int pageNumber, int pageSize)
        {
            var books = await _bookService.GetAllBooksAsync();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{bookId}")]
        public async Task<ActionResult<ResponseBookDTO>> GetBookByIdAsync(Guid bookId)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBookAsync(Guid bookId, RequestBookDTO requestBookDTO)
        {
            await _bookService.UpdateBookAsync(bookId, requestBookDTO);
            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddBookAsync(RequestBookDTO requestBookDTO)
        {
            var createdBook = await _bookService.AddBookAsync(requestBookDTO);
            return CreatedAtAction(nameof(GetBookByIdAsync), new { bookId = createdBook.BookId }, createdBook);
        }

        // DELETE: api/Books/5
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            var currentBook = await _bookService.GetBookByIdAsync(bookId);
            if (currentBook == null)
            {
                return NotFound();
            }
            await _bookService.DeleteBookAsync(bookId);
            return NoContent();
        }
    }
}