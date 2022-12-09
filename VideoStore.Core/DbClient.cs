using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VideoStore.Core;

namespace VideoStore
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Video> _videos;
        public DbClient(IOptions<VideostoreDbConfig> videostoreDbConfig)
        {
            var client = new MongoClient(videostoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(videostoreDbConfig.Value.Database_Name);
            _videos = database.GetCollection<Video>(videostoreDbConfig.Value.Videos_Collection_Name);
        }

        public IMongoCollection<Video> GetVideoCollecion() => _videos;
    }
}
