using MovieHandler.Domain;
using MovieHandler.Interfaces;
using System;

namespace MovieHandler.Controller
{
    public sealed class MovieHandlerFactory
    {
        private static readonly MovieHandlerFactory self = new MovieHandlerFactory();

        public static MovieHandlerFactory GetInstance { get { return self; } }

        public IMovieHandlerAuthentication GenerateMovieHandlerAuthentication(string appLevelAuthentication, string uri)
        {
            switch (appLevelAuthentication)
            {
                case "APIKey":
                    return new MovieHandlerAPIKeyAuthentication(uri);

                case "BearerToken":
                    return new MovieHandlerBearerTokenAuthentication(uri);
            }

            throw new Exception($"ApplicationLevelAuthentication: {appLevelAuthentication} not implemented!");
        }

        public IMovieHandlerFeature GenerateMovieHandlerFeature(string feature, IMovieHandlerAuthentication handlerAuthentication)
        {
            switch (feature)
            {
                case "Search":
                    return new MovieHandlerFeatureSearchMovie(handlerAuthentication);

                case "Detail":
                    return new MovieHandlerFeatureDetailMovie(handlerAuthentication);
            }

            throw new Exception($"Feature: {feature} not implemented!");
        }
    }
}
