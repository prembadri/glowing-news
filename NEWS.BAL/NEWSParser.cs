using Common.Helpers;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsCatcherAPI.Model;
using System.Collections.Generic;

namespace NEWS.BAL
{
    public class NEWSParser
    {

        private readonly NewsAPIClientHelper _newsAPIClientHelper = null;
        private readonly NewsCatcherAPIClientHelper _newsCatcherAPIClientHelper = null;
        public NEWSParser(string newsAPIKey,string newsCatcherAPIKey)
        {
            _newsAPIClientHelper = new NewsAPIClientHelper(newsAPIKey);
            _newsCatcherAPIClientHelper = new NewsCatcherAPIClientHelper(newsCatcherAPIKey);
        }

        public IEnumerable<string> TopHeadlines()
        {
            var headlines = _newsAPIClientHelper.GetTopHeadlines(Countries.IN);

            foreach (var headline in GetNewsAPIArtical(headlines))
            {
                yield return headline;
            }
        }

        private IEnumerable<string> GetNewsAPIArtical(List<NewsAPI.Models.Article> articles)
        {
            foreach (var item in articles)
            {
                yield return $"\"{item.Title}\",\"{item.PublishedAt}\",\"{item.Author}\",\"{item.Url}\",\"{item.UrlToImage}\",\"{item.Source.Name}\"";
            }
        }

        public IEnumerable<string> TopHeadLinesNewsCatcher() 
        {
            var headlines = _newsCatcherAPIClientHelper.GetTopHeadlines();

            foreach (var headline in GetNewsCatcherAPIArtical(headlines))
            {
                yield return headline;
            }
        }

        private IEnumerable<string> GetNewsCatcherAPIArtical(List<NewsCatcherAPI.Model.Article> articles)
        {
            foreach (var item in articles)
            {
                yield return $"\"{item.title}\",\"{item.published_date}\"";
            }
        }
    }
}
