using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Server.Dtos;
using VaccineApp.Shared.Models;

namespace VaccineApp.Server
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<Vaccination, VaccinationDto>();
        }
    }
}
