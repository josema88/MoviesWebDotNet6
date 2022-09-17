using Movies.Core.Constants;
using Movies.Core.Entities;
using Movies.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Movies.UnitTests.Core
{
    public class MovieHelperGetSatisfaction
    {
        [Fact]
        public void GetMovieSatisfactionBasedOnRating()
        {
            //Arrange
            var rating = 79;
            var movie = new Movie
            {
                Id = 1,
                Rating = rating,
                Title = "Shrek",
                Year = 1972,
            };

            //Act
            var satisfaction = movie.GetMovieSatisfaction();

            //Assert
            Assert.Equal(SatisfactionEnum.Buena, satisfaction);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(81)]
        public void GetMovieSatisfactionForExcelentMovies(int rating)
        {
            //Arrange
            var movie = new Movie
            {
                Id = 1,
                Rating = rating,
                Title = "Shrek",
                Year = 1972,
            };

            //Act
            var satisfaction = movie.GetMovieSatisfaction();

            //Assert
            Assert.Equal(SatisfactionEnum.Excelente, satisfaction);
        }

        [Theory]
        [MemberData(nameof(GoodMovieRatings))]
        public void GetMovieSatisfactionForGoodMovies(int rating)
        {
            //Arrange
            var movie = new Movie
            {
                Id = 1,
                Rating = rating,
                Title = "Shrek",
                Year = 1972,
            };

            //Act
            var satisfaction = movie.GetMovieSatisfaction();

            //Assert
            Assert.Equal(SatisfactionEnum.Buena, satisfaction);
        }

        public static IEnumerable<object[]> GoodMovieRatings()
        {
            var allData = new List<object[]>();
            for (int i = 61; i <= 80; i++)
            {
                allData.Add(new object[] { i });
            }
            return allData;
        }

        [Theory]
        [MemberData(nameof(NormalMovieRatings))]
        public void GetMovieSatisfactionForNormalMovies(int rating)
        {
            //Arrange
            var movie = new Movie
            {
                Id = 1,
                Rating = rating,
                Title = "Shrek",
                Year = 1972,
            };

            //Act
            var satisfaction = movie.GetMovieSatisfaction();

            //Assert
            Assert.Equal(SatisfactionEnum.Normal, satisfaction);
        }

        public static IEnumerable<object[]> NormalMovieRatings()
        {
            var allData = new List<object[]>();
            for (int i = 41; i <= 60; i++)
            {
                allData.Add(new object[] { i });
            }
            return allData;
        }

        [Theory]
        [MemberData(nameof(BadMovieRatings))]
        public void GetMovieSatisfactionForBadMovies(int rating)
        {
            //Arrange
            var movie = new Movie
            {
                Id = 1,
                Rating = rating,
                Title = "Shrek",
                Year = 1972,
            };

            //Act
            var satisfaction = movie.GetMovieSatisfaction();

            //Assert
            Assert.Equal(SatisfactionEnum.Mala, satisfaction);
        }

        public static IEnumerable<object[]> BadMovieRatings()
        {
            var allData = new List<object[]>();
            for (int i = 21; i <= 40; i++)
            {
                allData.Add(new object[] { i });
            }
            return allData;
        }

        [Theory]
        [MemberData(nameof(AwfulMovieRatings))]
        public void GetMovieSatisfactionForAwfulMovies(int rating)
        {
            //Arrange
            var movie = new Movie
            {
                Id = 1,
                Rating = rating,
                Title = "Shrek",
                Year = 1972,
            };

            //Act
            var satisfaction = movie.GetMovieSatisfaction();

            //Assert
            Assert.Equal(SatisfactionEnum.Terrible, satisfaction);
        }

        public static IEnumerable<object[]> AwfulMovieRatings()
        {
            var allData = new List<object[]>();
            for (int i = 0; i <= 20; i++)
            {
                allData.Add(new object[] { i });
            }
            return allData;
        }

        [Theory]
        [InlineData(101)]
        [InlineData(-1)]
        public void GetMovieSatisfactionForOutOfRangeRating(int rating)
        {
            //Arrange
            var movie = new Movie
            {
                Id = 1,
                Rating = rating,
                Title = "Shrek",
                Year = 1972,
            };

            //Act
            var satisfaction = movie.GetMovieSatisfaction();

            //Assert
            Assert.Equal(SatisfactionEnum.NA, satisfaction);
        }

    }
}
