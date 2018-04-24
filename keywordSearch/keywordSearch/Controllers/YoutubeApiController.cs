﻿using keywordSearch.API;
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

namespace keywordSearch.Controllers
{
    public class YoutubeApiController : ApiController
    {
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

                var youtubeSearchLogService = new YoutubeSearchLogService();
                youtubeSearchLogService.AddLog(youtubeSearchLog);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Ok(youtubeResponse);
        }
    }
}
