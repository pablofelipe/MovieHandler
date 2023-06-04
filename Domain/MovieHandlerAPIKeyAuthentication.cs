using System;
using System.Configuration;
using System.Net;

namespace MovieHandler.Domain
{
    public sealed class MovieHandlerAPIKeyAuthentication : MovieHandlerBase
    {
        private readonly string uri;
        private readonly string apiToken;

        public MovieHandlerAPIKeyAuthentication(string uri)
        {
            this.uri = uri;

            string configAPIKey = ConfigurationManager.AppSettings["APIKey"];

            if (string.IsNullOrEmpty(configAPIKey))
                throw new Exception($"You need to configure an APIkey to access the movie database website");

            apiToken = configAPIKey;
        }

        public override string Execute(string detail)
        {
            string response;
            using (var client = new WebClient())
            {
                client.Headers = LoadHeaders();

                string finalURI = uri + detail;

                if (finalURI.Contains("?"))
                    finalURI += "&";
                else
                    finalURI += "?";

                finalURI += "api_key=" + apiToken;

                response = client.DownloadString(finalURI);
            }

            return response;
        }
    }
}
