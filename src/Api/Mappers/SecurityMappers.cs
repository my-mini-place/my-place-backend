using AutoMapper;
using Domain.Models.Identity;
using Domain.ValueObjects;
using Infrastructure.Data;
using My_Place_Backend.DTO.AccountManagment;
using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Mappers
{
    public class SecurityMappers : Profile
    {
        public SecurityMappers()
        {
            CreateMap<RegisterDTO, User>()

                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                  //.ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                  //.ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                  //.ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
                  //.ForMember(dest => dest.ApartmentNumber, opt => opt.MapFrom(src => src.ApartmentNumber))
                  //.ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Floor))
                  //  .ForMember(dest => dest.Nickname, opt => opt.MapFrom(src => src.Nickname))
                  .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                  .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => AccountStatus.Pending))
                  .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                  .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<RegisterDTO, ApplicationUser>()

                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            CreateMap<User, UserDTO>()
     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId.ToString()))
     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
     .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))

     .ForMember(dest=> dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
     .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))

     .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
     .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}