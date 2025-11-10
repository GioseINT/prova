using AutoMapper;
using Prova.DAL.Entities;
using Prova.BLL.Models;
using Prova.Models;

namespace Prova.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            // Entities <=> BLL Models
            CreateMap<Pet, PetModel>().ReverseMap();
            CreateMap<Veterinary, VeterinaryModel>().ReverseMap();
            CreateMap<Appointment, AppointmentModel>().ReverseMap();

            // BLL Models <=> ViewModels
            CreateMap<PetModel, PetViewModel>().ReverseMap();
            CreateMap<VeterinaryModel, VeterinaryViewModel>().ReverseMap();
            CreateMap<AppointmentModel, AppointmentViewModel>().ReverseMap();
        }
    }
}
