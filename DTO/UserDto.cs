using System.ComponentModel.DataAnnotations;

namespace Assel.DTO
{
    public class UserDto
    {
        [Required]
        [StringLength(100)]
        public required string Id { get; set; }
    }
}
