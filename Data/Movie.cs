using System;

namespace MovieHandler.Data
{
    public class Movie
    {
        public int Id { get; set; }

        public string OriginalTitle { get; set; }

        public string ReleaseDate { get; set; }

        public string Overview { get; set; }

        public string Popularity { get; set; }

        public string Title { get; set; }

        public string Revenue { get; set; }

        public Movie GetMovie(dynamic curMovie)
        {
            Id = curMovie.id;
            OriginalTitle = curMovie.original_title;
            ReleaseDate = curMovie.release_date;
            Overview = curMovie.overview;
            Popularity = curMovie.popularity;
            Title = curMovie.title;
            Revenue = curMovie.revenue;

            return this;
        }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"OriginalTitle: {OriginalTitle}\n" +
                $"ReleaseDate: {ReleaseDate}\n" +
                $"Overview: {Overview}\n" +
                $"Popularity: {Popularity}\n" +
                $"Title: {Title}\n" +
                $"Revenue: {Convert.ToDecimal(Revenue).ToString("C")}";
        }
    }
}
