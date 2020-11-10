﻿
using Group4_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.DbData
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }

        void SaveMovie(Movie movie);
        Movie DeleteMovie(int movieID);
        Movie GetMovie(int id);
    }
}
    