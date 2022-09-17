using AutoMapper;
using Movies.Core.Entities;
using Movies.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.WebApp.Mapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();
        }
    }
}
