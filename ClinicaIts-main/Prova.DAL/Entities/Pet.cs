using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.DAL.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Species { get; set; }
        public string? Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Appointment> Appointment { get; set; } = new List<Appointment>();
    }
}
