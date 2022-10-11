using System;
using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models.Author;
using BookStore.API.Models.Book;
using BookStore.API.Models.User;

namespace BookStore.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
            CreateMap<AuthorUpdate, Author>().ReverseMap();

            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();
            CreateMap<Book, BookReadOnlyDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();
            CreateMap<Book, BookDetailDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();


            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}

