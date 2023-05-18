using ASP_Test.Core;
using System.Reflection;

namespace ASP_Test.Data
{
    public class TestData : IVideoData
    {
        List<Video> _videoList;
        public TestData()
        {
            _videoList = new List<Video>() {
                new Video { Id = 1, Title = "Миссия: Дебаг", ReleaseDate =
                new DateTime(2018, 1, 21), Genre = MovieGenre.Экшн, Price = 9.99, LentOut = false, LentTo = "" },
                new Video { Id = 2, Title = "Декомпиляция, когда у тебя в ассемблере лапки", ReleaseDate =
                new DateTime(2019, 7, 2), Genre = MovieGenre.Драма, Price = 6.66, LentOut = false, LentTo = ""  },
                new Video { Id = 3, Title = "Программист трахает тестировщицу", ReleaseDate =
                new DateTime(2020, 2, 14), Genre = MovieGenre.Романтика, Price = 69.96, LentOut = true, LentTo = "BrazzerZ"  }
            };
        }

        //public IEnumerable<Video> ListVideos() => _videoList.OrderBy(x => x.Title);
        public IEnumerable<Video> ListVideos(string title = null) => _videoList.Where(
            x => string.IsNullOrWhiteSpace(title)
            || x.Title.StartsWith(title)).OrderBy(x => x.Title);

        public Video GetVideo(int videoID) => _videoList.SingleOrDefault(x => x.Id == videoID);

        public Video UpdateVideo(Video updatedVideoData)
        {
            var dbObj = _videoList.SingleOrDefault(x => x.Id == updatedVideoData.Id);
            if (dbObj != null)
            {
                dbObj.Title = updatedVideoData.Title;
                dbObj.ReleaseDate = updatedVideoData.ReleaseDate;
                dbObj.Genre = updatedVideoData.Genre;
                dbObj.Price = updatedVideoData.Price;
                dbObj.LentOut = updatedVideoData.LentOut;   
                dbObj.LentTo = updatedVideoData.LentTo;
            }
            return dbObj;
        }

        public Video AddVideo(Video newVideo)
        {
            // находим максимальный ID в списке видео и прибавляем 1. Нормально работать будет только пока не набежит толпа пользователей...(
            newVideo.Id = _videoList.Max(x => x.Id) + 1;
            _videoList.Add(newVideo);
            return newVideo;
        }

        public int Save() => 0;

    }
}