using keywordSearch.Entities;
using keywordSearchEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keywordSearchData.DAL
{
    public class YoutubeSearchLogRepository : IYoutubeSearchLogRepository, IDisposable
    {
        private YoutubeSearchLogContext context;
        private bool disposed = false;

        public YoutubeSearchLogRepository()
        {
            this.context = new YoutubeSearchLogContext();
        }

        public void InsertLog(YoutubeSearchLog searchLog)
        {
            this.context.YoutubeSearchLogs.Add(searchLog);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
