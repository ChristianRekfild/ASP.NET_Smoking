using ASP_Test.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Test.Data
{
    internal class SQLData : IVideoData
    {
        private readonly VideoDbContext _database;
        public SQLData(VideoDbContext database)
        {
            _database = database;
        }

        public Video AddVideo(Video newVideo)
        {
            _ = _database.Add(newVideo);
            return newVideo;
        }

        public Video GetVideo(int videoID) => _database.Videos.Find(videoID);

        public IEnumerable<Video> ListVideos(string title) =>
            _database.Videos.Where(
                x => String.IsNullOrWhiteSpace(title)
                || x.Title.StartsWith(title))
                .OrderBy(x => x.Title);

        public int Save() => _database.SaveChanges();

        public Video UpdateVideo(Video videoData)
        {
            var entity = _database.Videos.Attach(videoData);
            entity.State = EntityState.Modified;
            return videoData;
        }
    }
}
