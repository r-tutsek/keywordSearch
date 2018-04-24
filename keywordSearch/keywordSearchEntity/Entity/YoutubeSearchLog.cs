using System;
using System.ComponentModel.DataAnnotations;

namespace keywordSearchEntity.Entity
{
    public class YoutubeSearchLog
    {
        [Key]
        public DateTime SearchDateTime { get; set; }
        public string SearchedKeyword { get; set; }
        public int SearchTotalResults { get; set; }
    }
}