using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using keywordSearch.Models;

namespace keywordSearch.Entities
{
    public class YoutubeSearchLogContext : DbContext
    {
        public DbSet<YoutubeSearchLog> youtubeSearchLogs { get; set; }
    }
}