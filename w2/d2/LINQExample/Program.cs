using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample
{
    class Program
    {
        public static void PrintMovies(IEnumerable<Movie> movies)
        {
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
        static void Main(string[] args)
        {

            List<Movie> movies = new List<Movie> {
                new Movie("Blood Diamond", "Leonardo DiCaprio", 8.5, 2006),
                new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
                new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
                new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
                new Movie("Good Will Hunting", "FAKE Matt Damon", 8.3, 1997),
                new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
                new Movie("The Martian", "Matt Damon", 8, 2015),
                new Movie("The Shining", "Jack Nicholson", 10, 1980),
                new Movie("Interstellar", "Matthew Mcconaughey", 9, 2016)
            };

            List<Actor> actors = new List<Actor> {
                new Actor { FullName = "Matt Damon", Age = 48 },
                new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
                new Actor { FullName = "Matthew Mcconaughey", Age = 45},
                new Actor { FullName = "Jack Nicholson crazy af", Age = 80 }
            };



            IEnumerable<Movie> filteredMovies = movies
                .Where(m => m.Title.StartsWith("T") && m.LeadActor == "Leonardo DiCaprio");

            // return new objects with only the Title and LeadActor
            // If you don't need all the data, better to only select what is needed
            var selected = movies.Select(m => new { m.Title, m.LeadActor });

            var moviedAndActors = movies
                .Join(actors, // join with actors list
                    movie => movie.LeadActor, // movie.LeadActor ==
                    actor => actor.FullName, // movie.FullName
                    (movie, actor) => new { movie, actor } // return new obj with movie and actor inside
                ).Where(movieAndActor => movieAndActor.actor.FullName == "Leonardo DiCaprio");

            // PrintMovies(filteredMovies);
        } // main
    }
}
