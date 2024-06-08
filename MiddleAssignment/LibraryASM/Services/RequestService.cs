
using Exceptions;
using Library.DTOs;
using Library.Models;
using LibraryASM.DTOs;
using LibraryASM.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryASM.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<BookBorrowingResponseDTO> AddRequestAsync(BookBorrowingResquestDTO requestDTO)
        {
            var request = new BookBorrowingRequest
            {
                UserId = requestDTO.UserId,
                DateRequested = DateTime.Now,
                RequestStatus = RequestStatus.Waiting,
                BorrowingRequestDetails = requestDTO.BorrowingRequestDetails.Select(d => new BookBorrowingRequestDetail
                {
                    BookId = d.BookId
                }).ToList()
            };

            await _requestRepository.AddRequestAsync(request);

            return new BookBorrowingResponseDTO
            {
                RequestId = request.RequestId,
                RequestStatus = request.RequestStatus,
                DateRequested = request.DateRequested,
                BorrowingRequestDetails = request.BorrowingRequestDetails.Select(d => new BookBorrowingRequestDetailDTO
                {
                    BookId = d.BookId,
                    RequestId = d.RequestId
                }).ToList()
            };
        }

        public async Task DeleteRequestAsync(Guid requestId)
        {
            var currentRequest = await _requestRepository.GetRequestByIdAsync(requestId);
            if (currentRequest == null)
            {
                throw new NotFoundException();
            }
            await _requestRepository.DeleteRequestAsync(requestId);
        }

        public async Task<BookBorrowingResponseDTO> GetRequestByIdAsync(Guid requestId)
        {
            var currentRequest = await _requestRepository.GetRequestByIdAsync(requestId);
            if (currentRequest == null)
            {
                throw new NotFoundException();
            }

            return new BookBorrowingResponseDTO
            {
                RequestId = currentRequest.RequestId,
                DateRequested = currentRequest.DateRequested,
                RequestStatus = currentRequest.RequestStatus,
                UserId = currentRequest.UserId,
                BorrowingRequestDetails = currentRequest.BorrowingRequestDetails.Select(d => new BookBorrowingRequestDetailDTO
                {
                    BookId = d.BookId,
                    RequestId = d.RequestId
                }).ToList()
            };
        }

        public async Task<List<BookBorrowingResponseDTO>> GetRequestsByUserAsync(Guid userId)
        {
            var userRequests = await _requestRepository.GetRequestsByUserAsync(userId);
            if (userRequests == null)
            {
                throw new NotFoundException();
            }

            return userRequests.Select(request => new BookBorrowingResponseDTO
            {
                RequestId = request.RequestId,
                DateRequested = request.DateRequested,
                RequestStatus = request.RequestStatus,
                UserId = request.UserId,
                BorrowingRequestDetails = request.BorrowingRequestDetails.Select(d => new BookBorrowingRequestDetailDTO
                {
                    BookId = d.BookId,
                    RequestId = d.RequestId
                }).ToList()
            }).ToList();
        }

        public async Task UpdateRequestStatus(Guid requestId, BookBorrowingResquestDTO requestDTO)
        {
            var currentRequest = await _requestRepository.GetRequestByIdAsync(requestId);
            if (currentRequest == null)
            {
                throw new NotFoundException();
            }
            currentRequest.RequestStatus = requestDTO.RequestStatus;
            await _requestRepository.UpdateRequestStatus(requestId, currentRequest);
        }
    }
}
