using Exceptions;
using LibraryASM.DTOs;
using LibraryASM.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryASM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowingRequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public BookBorrowingRequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: api/BookBorrowingRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookBorrowingResponseDTO>>> GetBookBorrowingRequests(Guid userId)
        {
            try
            {
                var requests = await _requestService.GetRequestsByUserAsync(userId);
                return Ok(requests);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/BookBorrowingRequests/5
        [HttpGet("{requestId}")]
        public async Task<ActionResult<BookBorrowingResponseDTO>> GetBookBorrowingRequest(Guid requestId)
        {
            try
            {
                var request = await _requestService.GetRequestByIdAsync(requestId);
                return Ok(request);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/BookBorrowingRequests/5
        [HttpPut("{requestId}")]
        public async Task<IActionResult> UpdateBookBorrowingRequest(Guid requestId, BookBorrowingResquestDTO bookBorrowingRequestDTO)
        {
            await _requestService.UpdateRequestStatus(requestId, bookBorrowingRequestDTO);
            return NoContent();
        }

        // POST: api/BookBorrowingRequests
        [HttpPost]
        public async Task<ActionResult<BookBorrowingResponseDTO>> AddBookBorrowingRequest(BookBorrowingResquestDTO bookBorrowingRequestDTO)
        {
            var createdRequest = await _requestService.AddRequestAsync(bookBorrowingRequestDTO);
            return CreatedAtAction("GetBookBorrowingRequest", new { id = createdRequest.RequestId }, createdRequest);
        }

        // DELETE: api/BookBorrowingRequests/5
        [HttpDelete("{requestId}")]
        public async Task<IActionResult> DeleteBookBorrowingRequest(Guid requestId)
        {
            try
            {
                await _requestService.DeleteRequestAsync(requestId);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
