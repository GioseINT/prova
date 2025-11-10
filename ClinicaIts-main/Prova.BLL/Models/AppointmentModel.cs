namespace Prova.BLL.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; } = string.Empty;
        public decimal Fee { get; set; }
        public int PetId { get; set; }
        public int VeterinayId { get; set; }
    }
}

