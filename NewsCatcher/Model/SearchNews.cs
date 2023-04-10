namespace NewsCatcherAPI.Model
{
    public class SearchNews
    {
        public string Query { get; set; }
        public string[] Language { get; set; }
        public string[] NotLanguage { get; set; }
        public string SearchIn { get; set; }
        public string[] Country { get; set; }
        public string[] NotCountry { get; set; }
        public string Topic { get; set; }
        public string[] Source { get; set; }
        public string[] NotSource { get; set; }
        public bool RankedOnly { get; set; }
        public int FromRank { get; set; }
        public int ToRank { get; set; }
        public string SortBy { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public string To { get; set; }
        public string From { get; set; }
    }
}
