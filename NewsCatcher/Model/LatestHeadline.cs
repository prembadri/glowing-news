using System.Collections.Generic;

namespace NewsCatcherAPI.Model
{
    public class LatestHeadline
    {
        /// The time period you want to get the latest headlines for.
        /// Accepted forms:
        /// - 7d => Dailly Form(last 7 days time period),  30d  (last 30 days time period)
        /// - 1h => Hourly Form(last hour), 24h(last 24 hours)
        public string When { get; set; }

        /// pecifies the languages of the search.For example, en.
        /// The only accepted format is ISO 639-1 — 2 letter code.
        /// Refer to the Allowed Languages section for more details.
        public string[] Language { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string[] Country { get; set; }

        //The inverse of the countries parameter.
        public string[] NotCountry { get; set; }

        /// Accepted values: news, sport,
        /// tech, world, finance,
        ///politics, business, economics, entertainment, beauty, travel, music, food, science, gaming, energy.
        public string Topic { get; set; }

        public string[] Source { get; set; }

        public string[] NotSource { get; set; }

        //True or false
        public string RankedOnly { get; set; }

        public int PageSize { get; set; }

        public int Page { get; set; }
    }
}
