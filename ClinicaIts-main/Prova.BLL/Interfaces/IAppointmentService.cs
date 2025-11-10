using Prova.BLL.Models;
using Prova.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.BLL.Interfaces
{
    public interface IAppointmentService : IGenericService<AppointmentModel, Appointment>
    {
    }
}

