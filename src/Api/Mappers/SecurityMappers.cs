using AutoMapper;
using Domain.Models.Identity;
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
            //CreateMap<RegisterDTO, User>
        }
    }
}