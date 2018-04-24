using keywordSearch.Entities;
using keywordSearchEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keywordSearchData.DAL
{
    public interface IYoutubeSearchLogRepository : IDisposable
    {
        void InsertLog(YoutubeSearchLog searchLog);
        void Save();
    }
}
