using Prova.DAL.Interfaces;
using Prova.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.DAL.Repositories
{
    public class VeterinaryRepository : GenericRepository<Veterinary>, IVeterinaryRepository
    {
        public VeterinaryRepository(AppDbConext db) : base(db)
        {
            
        }
    }
}
