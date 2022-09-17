using Microsoft.AspNetCore.Mvc;
using Moq;
using Movies.Core.Constants;
using Movies.Core.Entities;
using Movies.Core.Interfaces;
using Movies.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Movies.UnitTests.WebApi
{
    public class MoviesControllerActions
    {
        [Fact]
        public async Task GetAllMoviesActionTest()
        {
            //Arrange
            var moviesRepositoryMock = new Mock<IMovieRepository>();

            moviesRepositoryMock.Setup(mr => mr.GetMoviesAsync(It.IsAny<Movie>()))
                .ReturnsAsync(new List<Movie> {
                        new Movie { Id = 1,
                            Title = "Movie 1",
                            Year = 2018, Rating = 20,
                            Satisfaction = SatisfactionEnum.Terrible
                        },
                        new Movie { Id = 2,
                            Title = "Movie 2",
                            Year = 2019,
                            Rating = 60,
                            Satisfaction = SatisfactionEnum.Normal
                        }
                });

            var moviesController = new MoviesController(moviesRepositoryMock.Object);

            //Act
            var result = await moviesController.GetMoviesAsync(string.Empty);
            var objectResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetAndFoundMovieTest()
        {
            //Arrange
            var moviesRepositoryMock = new Mock<IMovieRepository>();

            moviesRepositoryMock.Setup(mr => mr.GetMovieAsync(It.IsAny<int>()))
                .ReturnsAsync(
                    new Movie { Id = 1,
                        Title = "Movie 1",
                        Year = 2018, Rating = 20,
                        Satisfaction = SatisfactionEnum.Terrible
                    });

            var moviesController = new MoviesController(moviesRepositoryMock.Object);

            //Act
            var result = await moviesController.GetMoviesAsync(1);
            var objectResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetAndNotFoundMovieTest()
        {
            //Arrange
            var moviesRepositoryMock = new Mock<IMovieRepository>();

            moviesRepositoryMock.Setup(mr => mr.GetMovieAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            var moviesController = new MoviesController(moviesRepositoryMock.Object);

            //Act
            var result = await moviesController.GetMoviesAsync(1);
            var objectResult = result as NotFoundObjectResult;

            //Assert
            Assert.NotNull(objectResult);
            Assert.Equal(404, objectResult.StatusCode);
            Assert.Equal("Movie not found", objectResult.Value);
        }
    }
}
