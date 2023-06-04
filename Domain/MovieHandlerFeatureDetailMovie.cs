using MovieHandler.Interfaces;

namespace MovieHandler.Domain
{
    public class MovieHandlerFeatureDetailMovie : IMovieHandlerFeature
    {
        private readonly IMovieHandlerAuthentication handlerAuthentication;

        public MovieHandlerFeatureDetailMovie(IMovieHandlerAuthentication handlerAuthentication)
        {
            this.handlerAuthentication = handlerAuthentication;
        }

        public string Execute(string movieID)
        {
            return handlerAuthentication.Execute($"movie/{movieID}");
        }
    }
}
