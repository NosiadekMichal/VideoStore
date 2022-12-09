using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Core
{
    public interface IVideoServices
    {
        List <Video> GetVideos();

        Video GetVideo(string id);
        Video AddVideo(Video video);

        void DeleteVideo(string id);

        Video UpdateVideo(Video video);
    }
}
