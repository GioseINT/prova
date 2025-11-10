using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.DAL.Entities
{
    public class Veterinary
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Qualification { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public ICollection<Appointment> Appointment { get; set; } = new List<Appointment>();
    }
}
