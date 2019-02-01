using AutoMapper;
using RMS.API.Dtos;
using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.API.Infarstructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Flight, FlightDTO>().ReverseMap();
            CreateMap<Movement, MovementDTO>().ReverseMap();
        }
    }
}
