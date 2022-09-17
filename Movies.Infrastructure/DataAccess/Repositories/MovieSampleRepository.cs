using Movies.Core.Entities;
using Movies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.DataAccess.Repositories
{
    public class MovieSampleRepository : IMovieRepository
    {
        public Task<Movie> AddMovieAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(Movie entity)
        {
            var movies = new List<Movie>()
            {
                new Movie() { Id = 1, Title = "Titanic", Year = 1997 },
                new Movie() { Id = 2, Title = "Space Jam", Year = 1995 }
            };
            return movies;
        }

        public Task<Movie> UpdateMovieAsync(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
