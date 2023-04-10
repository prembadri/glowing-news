using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsCatcherAPI;
using NewsCatcherAPI.Model;

namespace Common.Helpers
{
    public class NewsCatcherAPIClientHelper
    {
        private readonly string _apiKey;

        public NewsCatcherAPIClientHelper(string apiKeys)
        {
            _apiKey = apiKeys;
        }

        public List<Article> GetTopHeadlines()
        {
            var articles = new List<Article>();
            try
            {
                var newsApiClient = new NewsCatcherAPI.NewsCatcherAPI(_apiKey);


                var articlesResponse = newsApiClient.GetLatestHeadlines(new LatestHeadline()
                {
                    Country = new string[] { "IN" },
                    Language = new string[] { "en" },
                    Topic = "politics"
                });

                if (articlesResponse.status == "OK")
                {
                    articles = articlesResponse.articles;
                }
                else
                {
                    // log message 
                    //var message = articlesResponse.Error;
                }
            }
            catch (Exception ex)
            {
                //log message 
            }

            return articles;
        }
    }
}
