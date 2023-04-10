using System.Collections.Generic;

namespace NewsCatcherAPI.Model
{
    public class ArticlesResult
    {
        public string status { get; set; }
        public int total_hits { get; set; }
        public int page { get; set; }
        public int total_pages { get; set; }
        public int page_size { get; set; }
        public List<Article> articles { get; set; }
        public UserInput user_input { get; set; }
    }
}
