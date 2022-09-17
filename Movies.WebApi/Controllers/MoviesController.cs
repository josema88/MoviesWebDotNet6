using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Core.Entities;
using Movies.Core.Interfaces;
using Movies.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        /// <summary>
        /// Get all movies, and get movies by title.
        /// </summary>
        /// <remarks>
        /// If you didn't send parameters the endpoint will return all movies.
        /// </remarks>
        /// <param name="title">Movie Title</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Movie>))]
        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync(string title)
        {
            Movie entity = null;
            if (!string.IsNullOrEmpty(title))
            {
                entity = new Movie
                {
                    Title = title,
                };
            }
            var movies = await _movieRepository.GetMoviesAsync(entity);
            return Ok(movies);
        }

        /// <summary>
        /// Get a movie by Id
        /// </summary>
        /// <remarks>
        /// Send the Id in URI
        /// </remarks>
        /// <param name="id">Movie Id</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMoviesAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            return Ok(movie);
        }

        /// <summary>
        /// Create a movie
        /// </summary>
        /// <remarks>
        /// Send the Movie data in HTTP Request's body as JSON
        /// </remarks>
        /// <param name="movie"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync(Movie movie)
        {
            if (movie == null || string.IsNullOrEmpty(movie.Title))
            {
                return BadRequest("Movie object is null");
            }
            var result = await _movieRepository.AddMovieAsync(movie);
            return Ok(result);
        }

        /// <summary>
        /// Update a movie
        /// </summary>
        /// <remarks>
        /// Send the Movie data in HTTP Request's body as JSON.
        /// URI Id and Movie Id within JSON sould match.
        /// </remarks>
        /// <param name="id">Movie Id</param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest("Movie Id is different");
            }
            var result = await _movieRepository.UpdateMovieAsync(movie);
            if (result == null)
            {
                return NotFound("Movie Not Found");
            }
            return Ok(result);
        }

        /// <summary>
        /// Delete a movie
        /// </summary>
        /// <remarks>
        /// Send Id in the URI
        /// </remarks>
        /// <param name="id">Movie Id</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            var result = await _movieRepository.DeleteMovieAsync(id);
            if (result == null)
            {
                return NotFound($"Movie with Id = {id} not found");
            }
            return Ok($"Movie with Id = {id} was deleted");
        }
    }
}
