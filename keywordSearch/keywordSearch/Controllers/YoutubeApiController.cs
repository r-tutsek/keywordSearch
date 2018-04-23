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
        private List<YoutubeVideo> youtubeVideos;

        [HttpGet]
        public async Task<IHttpActionResult> SearchAsync(String queryStr)
        {
            try
            {
                youtubeVideos = await new YoutubeData().Run(queryStr);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Ok(youtubeVideos);
        }
    }
}
