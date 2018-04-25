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
        private readonly IYoutubeSearchLogRepository _youtubeSearchLogRepository;

        public YoutubeSearchLogService(IYoutubeSearchLogRepository youtubeSearchLogRepository)
        {
            this._youtubeSearchLogRepository = youtubeSearchLogRepository;
        }

        public void AddLog(YoutubeSearchLog youtubeSearchLog)
        {
            _youtubeSearchLogRepository.InsertLog(youtubeSearchLog);
            _youtubeSearchLogRepository.Save();
        }       
    }
}
