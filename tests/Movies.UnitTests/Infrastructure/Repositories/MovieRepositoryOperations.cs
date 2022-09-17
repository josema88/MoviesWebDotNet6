using Microsoft.EntityFrameworkCore;
using Movies.Core.Constants;
using Movies.Core.Entities;
using Movies.Infrastructure.DataAccess;
using Movies.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Movies.UnitTests.Infrastructure.Repositories
{
    public class MovieRepositoryOperations : IDisposable
    {
        private readonly DbContextOptions<ApplicationDbContext> options = 
            new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MovieDbInMemory")
            .Options;

        private ApplicationDbContext dbContext { get; set; }

        public ApplicationDbContext FillData()
        {
            dbContext = new ApplicationDbContext(options);

            dbContext.Movies.Add(new Movie { Id = 1, Title = "Movie 1", Year = 2018, Rating = 20, Satisfaction = SatisfactionEnum.Terrible });
            dbContext.Movies.Add(new Movie { Id = 2, Title = "Movie 2", Year = 2019, Rating = 60, Satisfaction = SatisfactionEnum.Normal });
            dbContext.Movies.Add(new Movie { Id = 3, Title = "Movie 3", Year = 2020, Rating = 100, Satisfaction = SatisfactionEnum.Excelente });
            dbContext.SaveChanges();
            return dbContext;
        }


        [Fact]
        public async Task GetAllMoviesTest()
        {
            //Arrange
            var dbContext = FillData();

            MovieRepository movieRepository = new MovieRepository(dbContext);

            //Act
            var movies = await movieRepository.GetMoviesAsync(null);

            //Assert
            Assert.Equal(3, movies.ToList().Count);
        }

        [Fact]
        public async Task DeleteMovieTest()
        {
            //Arrange
            var dbContext = FillData();

            MovieRepository movieRepository = new MovieRepository(dbContext);

            var movieIdToDelete = 2;

            //Act
            var movie = await movieRepository.DeleteMovieAsync(movieIdToDelete);
            var movies = await movieRepository.GetMoviesAsync(null);

            var deletedMovieSearch = await movieRepository.GetMovieAsync(movieIdToDelete);

            //Assert
            Assert.Equal(2, movies.ToList().Count);
            Assert.Null(deletedMovieSearch);
        }

        [Fact]
        public async Task InsertMovieTest()
        {
            //Arrange
            var dbContext = FillData();

            MovieRepository movieRepository = new MovieRepository(dbContext);

            var movie = new Movie
            {
                Id = 4,
                Rating = 75,
                Title = "Movie 4",
                Year = 2021,
            };

            //Act
            var movieAdded = await movieRepository.AddMovieAsync(movie);
            var movies = await movieRepository.GetMoviesAsync(null);

            var addedMovieSearch = await movieRepository.GetMovieAsync(movie.Id);

            //Assert
            Assert.Equal(4, movies.ToList().Count);
            Assert.Equal(movie.Id, addedMovieSearch.Id);
            Assert.Equal(SatisfactionEnum.Buena, addedMovieSearch.Satisfaction);
        }

        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
