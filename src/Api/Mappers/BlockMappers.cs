using Api.DTO.Blocks;
using Api.DTO.Residence;
using AutoMapper;
using Domain.Entities;
using Domain.Models.Identity;
using Domain.ValueObjects;
using Infrastructure.Data;
using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Mappers
{
    public class BlockMappers : Profile
    {
        public BlockMappers()
        {
            CreateMap<Block, BlockDTO>().ForMember(dest => dest.BlockId, opt => opt.MapFrom(src => src.BlockId))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Floors, opt => opt.MapFrom(src => src.Floors));


            CreateMap<BlockDTO, Block>().ForMember(dest => dest.BlockId, opt => opt.MapFrom(src => src.BlockId))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Floors, opt => opt.MapFrom(src => src.Floors));



            CreateMap<ResidenceDTO,Residence>().ForMember(dest => dest.ResidenceId, opt => opt.MapFrom(src => src.ResidenceId))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
                .ForMember(dest => dest.ApartmentNumber, opt => opt.MapFrom(src => src.ApartmentNumber))
                .ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Floor));

            CreateMap<Residence, ResidenceDTO>().ForMember(dest => dest.ResidenceId, opt => opt.MapFrom(src => src.ResidenceId))
               .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
               .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
               .ForMember(dest => dest.ApartmentNumber, opt => opt.MapFrom(src => src.ApartmentNumber))
               .ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Floor));
        }
    }
}
