
using MovieHandler.Data;
using System.Collections.Generic;

namespace MovieHandler.Controller
{
    public class JsonParserSearchMovie
    {
        public Dictionary<string, Movie> Parse(string json)
        {
            dynamic objMovies = Newtonsoft.Json.Linq.JObject.Parse(json);

            int movieCount = objMovies["results"].Count;

            var results = objMovies["results"];

            Dictionary<string, Movie> movies = new Dictionary<string, Movie>();

            for (int i = 0; i < movieCount; i++)
            {
                var curMovie = results[i];

                movies[curMovie.id.ToString()] = new Movie().GetMovie(curMovie);
            }

            return movies;
        }
    }
}
