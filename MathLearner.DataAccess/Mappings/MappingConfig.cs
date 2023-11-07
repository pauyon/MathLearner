﻿using AutoMapper;
using MathLearner.Domain.Dtos;
using MathLearner.Domain.Entities;

namespace MathLearner.PersistenceDatabaseEF.Mappings
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
