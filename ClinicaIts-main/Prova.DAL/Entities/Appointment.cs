using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.DAL.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; } = default!;
        public decimal Fee { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; } = default!;
        public int VeterinayId { get; set; }
        public Veterinary Veterinary { get; set; } = default!;

    }
}
