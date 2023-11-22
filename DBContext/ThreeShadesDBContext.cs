using MongoDB.Driver;
using DataModels;

namespace DBContext
{
    public class ThreeShadesDBContext
    {
        private readonly IMongoDatabase _database;

        public ThreeShadesDBContext(IMongoClient client, string dbName)
        {
            _database = client.GetDatabase(dbName);
        }

        public IMongoCollection<DutyModel> Duties
        {
            get
            {
                return _database.GetCollection<DutyModel>("Duties");
            }
        }

        public IMongoCollection<DutyStateModel> DutyStates
        {
            get
            {
                return _database.GetCollection<DutyStateModel>("DutyStates");
            }
        }

        public IMongoCollection<CommentModel> Comments
        {
            get
            {
                return _database.GetCollection<CommentModel>("Comments");
            }
        }
    }
}
