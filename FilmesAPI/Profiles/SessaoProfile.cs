﻿using AutoMapper;
using FilmesAPI.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<Sessao, ReadSessaoDto>();
            CreateMap<CreateSessaoDto, Sessao>();
        }
    }
}
