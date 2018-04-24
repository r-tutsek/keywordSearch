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

namespace keywordSearch.Controllers
{
    public class YoutubeApiController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> SearchAsync(String queryStr)
        {
            var youtubeResponse = new YoutubeResponse();
            youtubeResponse.baseUrl = "https://www.youtube.com/embed";
            youtubeResponse.thumbnailUrl = "https://img.youtube.com/vi";
            youtubeResponse.thumbnailDefaultImage = "mqdefault.jpg";
            try
            {
                youtubeResponse.videos = await new YoutubeData().Run(queryStr);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Ok(youtubeResponse);
        }
    }
}
