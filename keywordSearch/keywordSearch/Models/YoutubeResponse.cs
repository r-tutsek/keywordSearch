using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace keywordSearch.Models
{
    public class YoutubeResponse
    {
        public string baseUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string thumbnailDefaultImage { get; set; }
        public List<YoutubeVideo> videos { get; set; }
    }
}