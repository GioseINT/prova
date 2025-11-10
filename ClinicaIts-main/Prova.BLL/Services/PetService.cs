using AutoMapper;
using Prova.BLL.Interfaces;
using Prova.BLL.Models;
using Prova.DAL.Entities;
using Prova.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.BLL.Services
{
    public class PetService : GenericService<PetModel, Pet>, IPetService
    {
        public PetService(IGenericRepository<Pet> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

