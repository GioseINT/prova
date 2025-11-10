using Prova.DAL.Entities;
using Prova.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.BLL.Interfaces
{
    public interface IPetService : IGenericService<PetModel, Pet>
    {
    }
}

