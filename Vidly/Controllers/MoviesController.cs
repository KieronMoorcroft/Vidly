﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movies = new Movie() {Name = "Shrek" };

            var customers = new List<Customer>
            {

                new Customer {Name = "Customer 1" },
                new Customer {Name = "Customer 2" }
            };

            var viewmodel = new RandomMovieViewModel
            {
                Movie = movies,
                Customers = customers
            };

            return View(viewmodel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int? id)
        {
            return Content("id=" + id);  
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                  new Movie { Id = 1, Name = "Shrek" },
                  new Movie { Id = 2, Name = "Wall-e" }
            };
        }
    }
}