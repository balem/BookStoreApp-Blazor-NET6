using System;
using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models.Author;

namespace BookStore.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
            CreateMap<AuthorUpdate, Author>().ReverseMap();
        }
    }
}

