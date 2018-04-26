using keywordSearch.API;
using keywordSearch.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using keywordSearchService;
using keywordSearchEntity.Entity;
using Autofac;
using System.Reflection;
using keywordSearchData.DAL;

namespace keywordSearch.Controllers
{
    public class YoutubeApiController : ApiController
    {
        private readonly IYoutubeSearchLogService _youtubeSearchService;
        private readonly IYoutubeSearchLogRepository _youtubeSearchRepository;

        public YoutubeApiController(IYoutubeSearchLogService youtubeSearchService, IYoutubeSearchLogRepository youtubeSearchRepository)
        {
            this._youtubeSearchService = youtubeSearchService;
            this._youtubeSearchRepository = youtubeSearchRepository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> SearchAsync(String queryStr)
        {
            var youtubeResponse = new YoutubeResponse
            {
                BaseUrl = "https://www.youtube.com/embed",
                ThumbnailUrl = "https://img.youtube.com/vi",
                ThumbnailDefaultImage = "mqdefault.jpg"
            };
            try
            {
                var youtubeDataSearchResult = await new YoutubeData().Run(queryStr);
                youtubeResponse.Videos = youtubeDataSearchResult.YoutubeVideos;

                var youtubeSearchLog = new YoutubeSearchLog
                {
                    SearchDateTime = DateTime.Now,
                    SearchedKeyword = queryStr,
                    SearchTotalResults = youtubeDataSearchResult.TotalResults
                };

                _youtubeSearchService.AddLog(youtubeSearchLog);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Ok(youtubeResponse);
        }

        [HttpPost]
        public async Task<IHttpActionResult> SearchAsyncPost(YoutubeSearchRequest searchRequest)
        {
            var youtubeResponse = new YoutubeResponse
            {
                BaseUrl = "https://www.youtube.com/embed",
                ThumbnailUrl = "https://img.youtube.com/vi",
                ThumbnailDefaultImage = "mqdefault.jpg"
            };
            try
            {
                var youtubeDataSearchResult = await new YoutubeData().Run(searchRequest.Keyword);
                youtubeResponse.Videos = youtubeDataSearchResult.YoutubeVideos;

                var youtubeSearchLog = new YoutubeSearchLog
                {
                    SearchDateTime = DateTime.Now,
                    SearchedKeyword = searchRequest.Keyword,
                    SearchTotalResults = youtubeDataSearchResult.TotalResults
                };

                var assembly = Assembly.Load(searchRequest.NamespaceName);
                var type = assembly.GetType(searchRequest.NamespaceName + "." + searchRequest.ClassName);

                var constructor = type.GetConstructor(new Type[] { typeof(YoutubeSearchLogRepository) });
                var classObject = constructor.Invoke(new Object[] { this._youtubeSearchRepository });

                var method = type.GetMethod(searchRequest.MethodName);
                method.Invoke(classObject, new Object[] { youtubeSearchLog });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Ok(youtubeResponse);           
        }
    }
}
