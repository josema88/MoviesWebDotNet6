using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var movies = new Movie[]
            {
                new Movie { Id = 1, Title = "Avenger: Endgame", Year = 2019, Rating = 75 },
                new Movie { Id = 2, Title = "The Lion King", Year = 2019, Rating = 70},
                new Movie { Id = 3, Title = "Ip Man 4", Year = 2019, Rating = 80 },
                new Movie { Id = 4, Title = "Gemini Man", Year = 2019, Rating = 40 },
                new Movie { Id = 5, Title = "Downton Abbey", Year = 2020, Rating = 65 }
            };

            foreach (var movie in movies)
            {
                movie.Satisfaction = movie.GetMovieSatisfaction();
            }

            var characters = new Character[]
            {
                new Character { Id = 1, Name = "Tony Stark", MovieId = 1 },
                new Character { Id = 2, Name = "Steve Rogers", MovieId = 1 },
                new Character { Id = 3, Name = "Okoye", MovieId = 1 },
                new Character { Id = 4, Name = "Simba", MovieId = 2 },
                new Character { Id = 5, Name = "Nala", MovieId = 2 },
                new Character { Id = 6, Name = "Ip Man", MovieId = 3 },
                new Character { Id = 7, Name = "Henry Brogan", MovieId = 4 },
                new Character { Id = 8, Name = "Violet Crawley", MovieId = 5 },
                new Character { Id = 9, Name = "Lady Mary Crawley", MovieId = 5 }
            };

            modelBuilder.Entity<Movie>().HasData(movies);
            modelBuilder.Entity<Character>().HasData(characters);
            base.OnModelCreating(modelBuilder);
        }
    }
}
