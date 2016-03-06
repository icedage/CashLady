using MongoDB.Driver;
using System;
using System.Configuration;

namespace CashLady.Denormalizer.MongoDB.MongoRepository
{
    public class MongoContextProvider : IMongoContextProvider
    {
        private const string DefaultConnectionstringName = "MongoDBconnection";
        private readonly MongoDatabase _database;
        private MongoClient _client;
        private MongoUrl _mongoUrl;

        public MongoDatabase Database
        {
            get { return _database; }
        }

        public MongoUrl MongoUrl
        {
            get { return _mongoUrl; }
        }

        public MongoContextProvider()
            : this(DefaultConnectionstringName, null)
        {
        }

        public MongoContextProvider(string connectionStringName)
            : this(connectionStringName, null)
        {
        }

        public MongoContextProvider(string connectionStringName, string databaseName)
        {
            try
            {
                _mongoUrl = MongoUrl.Create(GetConnectionString(connectionStringName));

                _client = new MongoClient(_mongoUrl);

                _database = GetDatabase(string.IsNullOrEmpty(databaseName) ? _mongoUrl.DatabaseName : databaseName);
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// Retrieves the default connectionstring from the App.config or Web.config file.
        /// </summary>
        /// <returns>Returns the default connectionstring from the App.config or Web.config file.</returns>
        private string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        /// <summary>
        /// Creates and returns a MongoDatabase from the specified url.
        /// </summary>
        /// <param name="url">The url to use to get the database from.</param>
        /// <returns>Returns a MongoDatabase from the specified url.</returns>
        private MongoDatabase GetDatabase(string databaseName)
        {
            var server = _client.GetServer();

            return server.GetDatabase(databaseName);
        }

        public MongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
