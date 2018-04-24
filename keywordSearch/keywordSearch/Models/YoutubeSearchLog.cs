using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace keywordSearch.Models
{
    public class YoutubeSearchLog
    {
        [Key]
        public DateTime searchDateTime { get; set; }
        public string searchedKeyword { get; set; }        
        public int searchCount { get; set; }
    }
}