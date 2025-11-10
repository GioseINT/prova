using System.ComponentModel.DataAnnotations;

namespace Prova.Models
{
    public class PetViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Species { get; set; }

        [Required]
        [StringLength(50)]
        public string? Breed { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}

