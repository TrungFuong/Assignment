using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public record LoginRequestDTO
    {
        [StringLength(255)]
        public required string UserName { get; init; }
        [StringLength(255)]
        public required string Password { get; init; }
    }
}