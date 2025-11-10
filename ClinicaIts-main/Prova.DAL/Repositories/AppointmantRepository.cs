using Prova.DAL.Interfaces;
using Prova.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.DAL.Repositories
{
    public class AppointmantRepository : GenericRepository<Appointment>, IAppointmantRepository
    {
        public AppointmantRepository(AppDbConext db) : base(db)
        {
            
        }
    }
}
