using Movies.Core.Constants;
using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Helpers
{
    public static class MovieHelpers
    {
        public static SatisfactionEnum GetMovieSatisfaction(this Movie movie)
        {
            return movie.Rating switch
            {
                int n when (n < 0) => SatisfactionEnum.NA,
                int n when (n <= 20 && n >= 0) => SatisfactionEnum.Terrible,
                int n when (n <= 40 && n >= 21) => SatisfactionEnum.Mala,
                int n when (n <= 60 && n >= 41) => SatisfactionEnum.Normal,
                int n when (n <= 85 && n >= 81) => SatisfactionEnum.Buena,
                int n when (n <= 100 && n >=81) => SatisfactionEnum.Excelente,
                _ => SatisfactionEnum.NA,
            };
        }
    }
}
