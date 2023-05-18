using ASP_Test.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Test.Data
{
    public interface IVideoData
    {
        IEnumerable<Video> ListVideos(string title);
        Video GetVideo(int videoID);
        Video UpdateVideo(Video videoData);
        Video AddVideo(Video newVideo);
        int Save();
    }
}
