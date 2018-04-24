using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace keywordSearch.Models
{
    public class YoutubeResponse
    {
        public string BaseUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ThumbnailDefaultImage { get; set; }
        public List<YoutubeVideo> Videos { get; set; }
    }
}