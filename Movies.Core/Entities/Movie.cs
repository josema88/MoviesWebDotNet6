using Movies.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
        public SatisfactionEnum Satisfaction { get; set; }
    }
}
