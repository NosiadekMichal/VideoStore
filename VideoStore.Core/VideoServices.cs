using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace VideoStore.Core
{
    public class VideoServices : IVideoServices
    {
        private readonly IMongoCollection<Video> _videos;
        public VideoServices(IDbClient dbClient)
        {
            _videos = dbClient.GetVideoCollecion();
        }

        public Video AddVideo(Video video)
        {
            _videos.InsertOne(video);
            return video;
        }

        public void DeleteVideo(string id)
        {
            _videos.DeleteOne(video => video.Id == id);
        }

        public Video GetVideo(string id) => _videos.Find(video => video.Id == id).First();

        public List<Video> GetVideos() => _videos.Find(video => true).ToList();

        public Video UpdateVideo(Video video)
        {
            GetVideo(video.Id);
            _videos.ReplaceOne(v => v.Id == video.Id, video);
            return video;
        }

        


    }
}
