using MongoDB.Driver;
using VideoStore.Core;

namespace VideoStore
{
    public interface IDbClient
    {
        IMongoCollection<Video> GetVideoCollecion();
    }
}
