using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NewsCatcherAPI.Model;
using Newtonsoft.Json;

namespace NewsCatcherAPI
{
    /// <summary>
    /// https://docs.newscatcherapi.com/code-snippets/your-first-call
    /// </summary>
    public class NewsCatcherAPI
    {
        private string BASE_URL = "https://api.newscatcherapi.com/v2/";
        private HttpClient HttpClient;
        private string _apiKey;

        public NewsCatcherAPI(string apiKey)
        {
            _apiKey = apiKey;
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
        }

        public async Task<ArticlesResult> GetLatestHeadlinesAsync(LatestHeadline request)
        {
            List<string> queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(request.When))
            {
                queryParams.Add("when=" + request.When);
            }

            if (request.Language != null && request.Language.Length > 0)
            {
                queryParams.Add("lang=" + string.Join(",", request.Language));
            }

            if (request.Country != null && request.Country.Length > 0)
            {
                queryParams.Add("countries=" + string.Join(",", request.Country));
            }

            if (request.NotCountry != null && request.NotCountry.Length > 0)
            {
                queryParams.Add("not_countries=" + string.Join(",", request.NotCountry));
            }

            if (!string.IsNullOrWhiteSpace(request.Topic))
            {
                queryParams.Add("topic=" + request.Topic);
            }

            if (request.Source != null && request.Source.Length > 0)
            {
                queryParams.Add("source=" + string.Join(",", request.Source).ToLowerInvariant());
            }

            if (request.NotSource != null && request.NotSource.Length > 0)
            {
                queryParams.Add("not_source=" + string.Join(",", request.NotSource));
            }

            if (!string.IsNullOrWhiteSpace(request.RankedOnly))
            {
                queryParams.Add("rank_only=" + request.RankedOnly);
            }

            if (request.PageSize != 0)
            {
                queryParams.Add("page_size=" + request.PageSize);
            }

            if (request.Page != 0)
            {
                queryParams.Add("page=" + request.Page);
            }

            string querystring = string.Join("&", queryParams.ToArray());

            return await MakeRequest("latest_headlines", querystring);
        }

        public ArticlesResult GetLatestHeadlines(LatestHeadline request)
        {
            return GetLatestHeadlinesAsync(request).Result;
        }

        public async Task<ArticlesResult> GetNewsBySearchAsync(SearchNews request)
        {
            List<string> queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(request.Query))
            {
                queryParams.Add("q=" + string.Join(",", request.Query));
            }

            if (request.Language != null && request.Language.Length > 0)
            {
                queryParams.Add("lang=" + string.Join(",", request.Language));
            }

            if (request.NotLanguage != null && request.NotLanguage.Length > 0)
            {
                queryParams.Add("lang=" + string.Join(",", request.NotLanguage));
            }

            if (!string.IsNullOrWhiteSpace(request.SearchIn))
            {
                queryParams.Add("q=" + string.Join(",", request.SearchIn));
            }

            if (request.Country != null && request.Country.Length > 0)
            {
                queryParams.Add("countries=" + string.Join(",", request.Country));
            }

            if (request.NotCountry != null && request.NotCountry.Length > 0)
            {
                queryParams.Add("not_countries=" + string.Join(",", request.NotCountry));
            }

            if (!string.IsNullOrWhiteSpace(request.Topic))
            {
                queryParams.Add("topic=" + request.Topic);
            }

            if (request.RankedOnly)
            {
                queryParams.Add("topic=true");
            }
            else
            {
                queryParams.Add("topic=false");
            }

            if (request.FromRank != 0)
            {
                queryParams.Add("topic=" + request.FromRank);
            }

            if (request.ToRank != 0)
            {
                queryParams.Add("topic=" + request.ToRank);
            }

            if (!string.IsNullOrWhiteSpace(request.SortBy))
            {
                queryParams.Add("q=" + string.Join(",", request.SortBy));
            }

            if (request.PageSize != 0)
            {
                queryParams.Add("page_size=" + request.PageSize);
            }

            if (request.Page != 0)
            {
                queryParams.Add("page=" + request.Page);
            }

            if (!string.IsNullOrWhiteSpace(request.To))
            {
                queryParams.Add("q=" + string.Join(",", request.To));
            }

            if (!string.IsNullOrWhiteSpace(request.From))
            {
                queryParams.Add("q=" + string.Join(",", request.From));
            }

            string querystring = string.Join("&", queryParams.ToArray());

            return await MakeRequest("search", querystring);
        }

        public ArticlesResult GetNewsBySearch(SearchNews request)
        {
            return GetNewsBySearchAsync(request).Result;
        }

        private async Task<ArticlesResult> MakeRequest(string endpoint, string querystring)
        {
            ArticlesResult articlesResult = new ArticlesResult();
            try
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, BASE_URL + endpoint + "?" + querystring);
                string json = await ((await HttpClient.SendAsync(httpRequest)).Content?.ReadAsStringAsync());
                if (!string.IsNullOrWhiteSpace(json))
                {
                    var apiResponse = JsonConvert.DeserializeObject<ArticlesResult>(json);
                    articlesResult.status = apiResponse.status;
                    if (articlesResult.status == "OK")
                    {
                        articlesResult = apiResponse;
                    }
                    else
                    {
                    }
                }
                else
                {
                    // "The API returned an empty response. Are you connected to the internet?";
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return articlesResult;
        }
    }
}
