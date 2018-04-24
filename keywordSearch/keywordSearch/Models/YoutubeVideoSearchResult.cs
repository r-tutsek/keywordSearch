using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace keywordSearch.Models
{
    public class YoutubeVideoSearchResult
    {
        public List<YoutubeVideo> YoutubeVideos { get; set; }
        public int TotalResults { get; set; }
    }
}