using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using keywordSearchData.DAL;
using keywordSearchEntity.Entity;
using keywordSearchService.Service;

namespace keywordSearchService
{
    public class YoutubeSearchLogService : IYoutubeSearchLogService
    {
        private bool disposed = false;

        public void AddLog(YoutubeSearchLog youtubeSearchLog)
        {
            var youtubeSearchLogRepo = new YoutubeSearchLogRepository();
            youtubeSearchLogRepo.InsertLog(youtubeSearchLog);
            youtubeSearchLogRepo.Save();
        }       
    }
}
