using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Helpers;
using Movies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movie> AddMovieAsync(Movie entity)
        {
            entity.Satisfaction = entity.GetMovieSatisfaction();
            var result = await _dbContext.Movies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Movie> DeleteMovieAsync(int id)
        {
            var result = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (result != null)
            {
                _dbContext.Movies.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(Movie entity)
        {
            if (entity == null)
            {
                return await _dbContext.Movies.Include(m => m.Characters).ToListAsync();
            }
            return await _dbContext.Movies.Include(m => m.Characters).Where(m => m.Title.Contains(entity.Title.ToLower())).ToListAsync();
        }

        public async Task<Movie> UpdateMovieAsync(Movie entity)
        {
            var result = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == entity.Id);
            if (result != null)
            {
                result.Satisfaction = entity.GetMovieSatisfaction();
                result.Title = entity.Title;
                result.Year = entity.Year;
                result.Rating = entity.Rating;
                result.Characters = entity.Characters;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
