using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace keywordSearch.Models
{
    public class YoutubeSearchRequest
    {
        public string Keyword { get; set; }
        public string NamespaceName { get; set; } 
        public string ClassName { get; set; }
        public string MethodName { get; set; }
    }
}