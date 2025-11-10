using System.ComponentModel.DataAnnotations;

namespace Prova.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(200)]
        public string Reason { get; set; } = string.Empty;

        [Required]
        [Range(0, 1000000)]
        public decimal Fee { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Pet")]
        public int PetId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Veterinary")]
        public int VeterinayId { get; set; }
    }
}
