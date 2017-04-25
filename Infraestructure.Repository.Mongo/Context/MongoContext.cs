namespace Infraestructure.Repository.Mongo
{
    using System;
    using System.Configuration;
    using MongoDB.Driver;

    public class MongoContext : IMongoContext
    {

        private IMongoDatabase database;

        public MongoContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["defaultMongo"].ConnectionString;
            var databaseName = ConfigurationManager.AppSettings["CodeGamesDb"];
            IMongoClient client = new MongoClient(connectionString);
            this.database = client.GetDatabase(databaseName);
        }


        public IMongoCollection<T> GetCollection<T>()
        {
            return this.database.GetCollection<T>(typeof(T).Name);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            this.database = null;
        }
    }
}
