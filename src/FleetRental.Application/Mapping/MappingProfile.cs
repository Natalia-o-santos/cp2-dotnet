using AutoMapper;
using FleetRental.Application.DTOs;
using FleetRental.Domain.Entities;

namespace FleetRental.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Rider, RiderResponse>();
        CreateMap<Motorcycle, MotorcycleResponse>();
    }
}
