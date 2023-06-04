using MovieHandler.Interfaces;

namespace MovieHandler.Domain
{
    public class MovieHandlerFeatureSearchMovie : IMovieHandlerFeature
    {
        private readonly IMovieHandlerAuthentication handlerAuthentication;

        public MovieHandlerFeatureSearchMovie(IMovieHandlerAuthentication handlerAuthentication)
        {
            this.handlerAuthentication = handlerAuthentication;
        }

        public string Execute(string queryMovie)
        {
            return handlerAuthentication.Execute($"search/movie?query={queryMovie}");
        }
    }
}
