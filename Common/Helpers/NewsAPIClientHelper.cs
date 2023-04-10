using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class NewsAPIClientHelper
    {
        private readonly string _apiKey;

        public NewsAPIClientHelper(string apiKeys)
        {
            _apiKey = apiKeys;
        }

        public List<Article> GetTopHeadlines(Countries countries)
        {
            var articles = new List<Article>();
            try
            {
                var newsApiClient = new NewsApiClient(_apiKey);
                

                var articlesResponse = newsApiClient.GetTopHeadlines(new TopHeadlinesRequest()
                {
                    Country = countries,
                    Language = Languages.EN,
                });

                if (articlesResponse.Status == Statuses.Ok)
                {
                    articles = articlesResponse.Articles;
                }
                else
                {
                    // log message 
                    var message = articlesResponse.Error.Message;
                }

                
            }
            catch (Exception ex)
            {
                //log message 
            }

            return articles;
        }

        public List<Article> GetEverything(string qustion, DateTime dateTime)
        {
            var articles = new List<Article>();
            try
            {
                var newsApiClient = new NewsApiClient(_apiKey);
                
                var articlesResponse = newsApiClient.GetEverything(new EverythingRequest()
                {
                    Language = Languages.EN,
                    Q = qustion,
                    From = dateTime,
                });

                if (articlesResponse.Status == Statuses.Ok)
                {
                    return articlesResponse.Articles;
                }
                else
                {
                    // log message 
                    var message = articlesResponse.Error.Message;
                }
            }
            catch (Exception ex)
            {
                //log mesage 
            }

            return articles;
        }
    }
}
