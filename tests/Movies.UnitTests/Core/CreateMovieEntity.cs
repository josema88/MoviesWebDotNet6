using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Movies.UnitTests.Core
{
    public class CreateMovieEntity
    {
        [Fact]
        public void CreateMovieObject()
        {
            var movie = new Movie
            {
                Id = 1,
                Rating = 89,
                Title = "Shrek",
                Year = 2003,
            };

            Assert.Equal(1, movie.Id);
            Assert.Equal(89, movie.Rating);
            Assert.True(movie.Characters.Count() == 0);
        }
    }
}
