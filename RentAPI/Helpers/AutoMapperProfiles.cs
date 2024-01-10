using AutoMapper;
using RentAPI.DTOs.Flats;
using RentAPI.Models;

namespace RentAPI.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<FlatAddDto, Flat>();
        CreateMap<FlatAddDto, Address>();
    }
}