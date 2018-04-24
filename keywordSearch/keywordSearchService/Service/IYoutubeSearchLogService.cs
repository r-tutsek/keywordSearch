using keywordSearchEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keywordSearchService.Service
{
    public interface IYoutubeSearchLogService
    {
        void AddLog(YoutubeSearchLog youtubeSearchLog);
    }
}
