namespace NewsCatcherAPI.Model
{
    public class Article
    {
        public string title { get; set; }

        public string author { get; set; }

        public string published_date { get; set; }

        public string published_date_precision { get; set; }

        public string link { get; set; }

        public string clean_url { get; set; }

        public string excerpt { get; set; }

        public string summary { get; set; }

        public string rights { get; set; }

        public int rank { get; set; }

        public string topic { get; set; }

        public string country { get; set; }

        public string language { get; set; }

        public string authors { get; set; }

        public string media { get; set; }

        public bool is_opinion { get; set; }

        public string twitter_account { get; set; }

        public object _score { get; set; }

        public string _id { get; set; }
    }
}
