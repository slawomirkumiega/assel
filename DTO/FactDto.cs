using System.ComponentModel.DataAnnotations;

namespace Assel.DTO
{
    public class FactDto
    {
        [Required]
        [StringLength(100)]
        public required string Id { get; set; }

        [Required]
        [StringLength(400)]
        public required string FactText { get; set; }

        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        [EnumDataType(typeof(PetType))]
        public required PetType PetType { get; set; }
    }
}
