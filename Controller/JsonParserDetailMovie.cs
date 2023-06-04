
using MovieHandler.Data;

namespace MovieHandler.Controller
{
    public class JsonParserDetailMovie
    {
        public Movie Parse(string json)
        {
            dynamic objMovie = Newtonsoft.Json.Linq.JObject.Parse(json);

            return new Movie().GetMovie(objMovie);
        }
    }
}
