using System;
using Sibly.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Sibly.Dtos;



namespace Sibly.Controllers.Api
{
    public class MoviesController : ApiController
    {

       public ApplicationDbContext _context;

       public MoviesController()
       {
           _context = new ApplicationDbContext();
       }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movies);
        }

        //Api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(Int16 Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.MovieId == Id);
            if (movie==null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }


        //Api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto moviedto)
        {
            if (!ModelState.IsValid)
            {
              return BadRequest(); 
            }
            var movie = Mapper.Map<MovieDto, Movie>(moviedto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            moviedto.MovieId = movie.MovieId;
            return Created(new Uri(Request.RequestUri + "/" + moviedto.MovieId), moviedto);
        }

        //Api/movies
        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, MovieDto moviedto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var customerInDB = _context.Movies.SingleOrDefault(m => m.MovieId == Id);
            customerInDB.Name = moviedto.Name;
            customerInDB.NumberInStock = moviedto.NumberInStock;
            customerInDB.ReleaseDate = moviedto.ReleaseDate;
            customerInDB.GenreId = moviedto.GenreId;
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + moviedto.MovieId), moviedto);

 
        }

        //Api/movies/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var customerInDB = _context.Movies.SingleOrDefault(m => m.MovieId == Id);
            _context.Movies.Remove(customerInDB);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.Accepted);

        }

    }
}
