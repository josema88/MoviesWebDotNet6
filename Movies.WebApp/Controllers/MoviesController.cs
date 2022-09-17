using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Core.Entities;
using Movies.Core.Interfaces;
using Movies.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.WebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var movie = string.IsNullOrEmpty(searchString) ? null : new Movie { Title = searchString };
            var movies = await _movieRepository.GetMoviesAsync(movie);
            var moviesViewModel = _mapper.Map<IEnumerable<MovieViewModel>>(movies).ToList();//.OrderByDescending(m => m.Rating);
            return View(moviesViewModel);
        }

        //HTTP Get Crete
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //HTTP Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var movieEntity = _mapper.Map<Movie>(movie);
                await _movieRepository.AddMovieAsync(movieEntity);
                TempData["mensaje"] = "La pelicula se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP Get Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movie = await _movieRepository.GetMovieAsync((int)id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieViewModel = _mapper.Map<MovieViewModel>(movie);
            return View(movieViewModel);
        }

        //HTTP Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var movieEntity = _mapper.Map<Movie>(movie);
                await _movieRepository.UpdateMovieAsync(movieEntity);
                TempData["mensaje"] = "La pelicula se actualizo correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP Get Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movie = await _movieRepository.GetMovieAsync((int)id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieViewModel = _mapper.Map<MovieViewModel>(movie);
            return View(movieViewModel);
        }

        //HTTP Post Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieRepository.DeleteMovieAsync((int)id);
            if (result == null)
            {
                return NotFound();
            }
            TempData["mensaje"] = "La pelicula se ha eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
