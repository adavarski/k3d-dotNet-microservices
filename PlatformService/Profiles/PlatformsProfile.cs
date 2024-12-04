﻿using AutoMapper;
using PaltformService.DTOs;
using PaltformService.Models;

namespace PaltformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformReadDTO>();
            CreateMap<PlatformCreateDTO, Platform>();
            CreateMap<PlatformReadDTO, PlatformPublishDTO>();
            CreateMap<Platform, GrpcPlatformModel>()
                .ForMember(
                    dest => dest.PlatformId, 
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Publisher,
                    opt => opt.MapFrom(src => src.Publisher)
                );
        }
    }
}
