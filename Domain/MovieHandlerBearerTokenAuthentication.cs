using System;
using System.Configuration;
using System.Net;

namespace MovieHandler.Domain
{
    public class MovieHandlerBearerTokenAuthentication : MovieHandlerBase
    {
        private readonly string uri;
        private readonly string bearerToken;

        public MovieHandlerBearerTokenAuthentication(string uri)
        {
            this.uri = uri;

            string configBearerToken = ConfigurationManager.AppSettings["BearerToken"];

            if (string.IsNullOrEmpty(configBearerToken))
                throw new Exception($"You need to configure an BearerToken to access the movie database website");

            bearerToken = configBearerToken;
        }

        public override string Execute(string detail)
        {
            string response;
            using (var client = new WebClient())
            {
                client.Headers = LoadHeaders();

                client.Headers["Authorization"] = "Bearer " + bearerToken;

                string finalURI = uri + detail;

                response = client.DownloadString(finalURI);
            }

            return response;
        }
    }
}
