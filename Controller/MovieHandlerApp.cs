using MovieHandler.Data;
using MovieHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MovieHandler.Controller
{
    public class MovieHandlerApp
    {
        private readonly string uri;
        public MovieHandlerApp(string uri)
        {
            this.uri = uri;
        }

        private bool GetBooleanValue(string varUserEntry)
        {
            string userEntry = varUserEntry.Trim().ToLower();

            if (userEntry.Equals("yes", StringComparison.OrdinalIgnoreCase))
                userEntry = "true";
            else if (userEntry.Equals("no", StringComparison.OrdinalIgnoreCase))
                userEntry = "false";

            return (!string.IsNullOrEmpty(userEntry) && bool.TryParse(userEntry, out bool entry) && entry);
        }

        public void Execute()
        {
            string appLevelAuthentication = ConfigurationManager.AppSettings["ApplicationLevelAuthentication"];

            IMovieHandlerAuthentication handlerAuthentication = MovieHandlerFactory.GetInstance.GenerateMovieHandlerAuthentication(appLevelAuthentication, uri);

            IMovieHandlerFeature currentFeature;
            string response;
            Dictionary<string, Movie> dictMovies;
            bool tryAgain;
            do
            {
                Console.WriteLine("Enter the movie you want information");

                string movieQuery = Console.ReadLine();

                currentFeature = MovieHandlerFactory.GetInstance.GenerateMovieHandlerFeature("Search", handlerAuthentication);

                response = currentFeature.Execute(movieQuery);

                dictMovies = new JsonParserSearchMovie().Parse(response);

                if (null == dictMovies || dictMovies.Count == 0)
                {
                    Console.WriteLine("We couldn't find any movies with the characteristics you're looking for. Do you want to try again?");
                    tryAgain = GetBooleanValue(Console.ReadLine());

                    if (!tryAgain)
                    {
                        Console.WriteLine("Thank you!");
                        return;
                    }
                }
                else
                    tryAgain = false;

            } while (tryAgain);

            foreach (var movieKeyPair in dictMovies)
            {
                var movieOverview = movieKeyPair.Value;

                Console.WriteLine($"{movieOverview.Id}\t{movieOverview.OriginalTitle}\t{movieOverview.ReleaseDate}");
            }

            Console.WriteLine("Do you want to see more information about some movie?");

            bool moreDetail = GetBooleanValue(Console.ReadLine());

            if (!moreDetail)
            {
                Console.WriteLine("Thanks. See you later");
                return;
            }

            Movie movieForDetails;
            bool movieNotFound;
            do
            {
                Console.WriteLine("Which movie id do you want to see more details?");
                string userMovieID = Console.ReadLine();

                if (!dictMovies.TryGetValue(userMovieID, out movieForDetails))
                {
                    Console.WriteLine("We couldn't find the movieID you're looking for. Do you want to try again?");
                    tryAgain = GetBooleanValue(Console.ReadLine());

                    if (!tryAgain)
                    {
                        Console.WriteLine("Thanks a lot. Bye!");
                        return;
                    }

                    movieNotFound = true;
                }
                else
                    movieNotFound = false;

            } while (movieNotFound);

            currentFeature = MovieHandlerFactory.GetInstance.GenerateMovieHandlerFeature("Detail", handlerAuthentication);

            response = currentFeature.Execute(movieForDetails.Id.ToString());

            Movie movie = new JsonParserDetailMovie().Parse(response);

            Console.WriteLine(movie.ToString());
        }
    }
}
