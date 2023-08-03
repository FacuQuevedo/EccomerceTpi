using AutoMapper;
using Model.Models;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings.Profiles
{
    public class UserProfile:Profile
    {
            
       public UserProfile() 
        {

            CreateMap<Users, UserDTO>().ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.IdRol));
            CreateMap<Users, CreateUser>();
        }
    }
}
