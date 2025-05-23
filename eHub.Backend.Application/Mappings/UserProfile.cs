﻿using AutoMapper;
using eHub.Backend.Domain.Entities;
using eHub.Backend.Domain.Models;

namespace eHub.Backend.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();

            CreateMap<UserModel, UserResponseModel>()
                .ReverseMap();

            CreateMap<User, UserResponseModel>()
                .ReverseMap();

            CreateMap<User, RegisterUserModel>()
                .ReverseMap();

            CreateMap<User, CompleteUserProfileModel>()
                .ReverseMap();
        }
    }
}
