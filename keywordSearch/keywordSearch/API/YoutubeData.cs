using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using keywordSearch.Models;

namespace keywordSearch.API
{
    public class YoutubeData
    {
        public async Task<YoutubeVideoSearchResult> Run(String keyword)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCvL2DX6Pa0RH63cxaa9DVyHtYhL5Oh8U0",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();
            
            var videos = new List<YoutubeVideo>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        var youtubeVideo = new YoutubeVideo
                        {
                            Id = searchResult.Id.VideoId,
                            Title = searchResult.Snippet.Title,
                            Description = searchResult.Snippet.Description
                        };
                        videos.Add(youtubeVideo);
                        break;
                }
            }

            var youtubeVideoSearchResult = new YoutubeVideoSearchResult
            {
                YoutubeVideos = videos,
                TotalResults = searchListResponse.PageInfo.TotalResults.Value
            };
            return youtubeVideoSearchResult;
        }
    }
}