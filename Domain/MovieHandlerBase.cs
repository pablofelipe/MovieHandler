using MovieHandler.Controller;
using MovieHandler.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace MovieHandler
{
    public abstract class MovieHandlerBase : IMovieHandlerAuthentication
    {
        private readonly Dictionary<string, string> requestHeader = null;

        public MovieHandlerBase()
        {
            requestHeader = MovieHandlerRequestHeaderGenerator.Generate();
        }

        public abstract string Execute(string detail);

        protected WebHeaderCollection LoadHeaders()
        {
            if (null == requestHeader)
                return null;

            WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
            foreach (var header in requestHeader)
            {
                if (!string.IsNullOrEmpty(header.Value))
                    webHeaderCollection[header.Key] = header.Value;
            }

            return webHeaderCollection;
        }
    }
}
