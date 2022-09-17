using Movies.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.WebApp.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo de la pelicula es requerido")]
        [StringLength(100, ErrorMessage = "La logintud minima es {2} y la maxima es {1}", MinimumLength = 3)]
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Required(ErrorMessage = "El año de la pelicula es requerido")]
        [Range(1890, 2030, ErrorMessage = "El año debe ser entre 1890 y 2030")]
        [Display(Name = "Año de lanzamiento")]
        public int Year { get; set; }
        [Required(ErrorMessage = "La calificacion de la pelicula es requerida")]
        [Range(0, 100, ErrorMessage = "La calificacion debe ser entre 0 y 100")]
        [Display(Name = "Calificacion")]
        public int Rating { get; set; }
        [Display(Name = "Satisfaccion")]
        public SatisfactionEnum Satisfaction { get; set; }
    }
}
