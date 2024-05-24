using System.ComponentModel.DataAnnotations;

namespace users.DTO
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string Surname { get; set; }

        [Required]
        public required string Login { get; set; }
    }
}
