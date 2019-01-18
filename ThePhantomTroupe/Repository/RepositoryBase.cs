using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;

namespace ThePhantomTroupe.Repository
{
    public abstract class RepositoryBase
    {
        MongoClientSettings _settings;
        MongoClientSettings Settings
        {
            get
            {
                if (null == _settings)
                    InitializeSettings();
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }

        MongoClient _client;
        MongoClient Client
        {
            get
            {
                if (null == _client)
                    _client = new MongoClient(Settings);
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        protected T GetOne<T>(Collection collectionName, string key, string value)
        {
            return GetCollection<T>(collectionName).Find(new BsonDocument(key, key)).FirstOrDefault();
        }

        protected IEnumerable<T> GetMany<T>(Collection collectionName, BsonDocument filter)
        {
            return GetCollection<T>(collectionName).Find(filter).ToList();
        }

        protected void InsertOne<T>(Collection collectionName, T data)
        {
            GetCollection<T>(collectionName).InsertOne(data);
        }

        protected void InsertMany<T>(Collection collectionName, IEnumerable<T> data)
        {
            GetCollection<T>(collectionName).InsertMany(data);
        }

        // Nicht geworken :S
        protected void InitializeEnvironment<T>()
        {
            var database = Client.GetDatabase(System.Configuration.ConfigurationManager.AppSettings["MongoDb:DbName"]);
            foreach (Collection collection in (Collection[])Enum.GetValues(typeof(Collection)))
            {
                if (null == database.GetCollection<T>(collection.ToString()))
                    database.CreateCollection(collection.ToString());
            }
        }

        IMongoCollection<T> GetCollection<T>(Collection collectionName)
        {
            var database = Client.GetDatabase(System.Configuration.ConfigurationManager.AppSettings["MongoDb:DbName"]);
            var collection = database.GetCollection<T>(collectionName.ToString());
            return collection;
        }

        void InitializeSettings()
        {
            string userName = System.Configuration.ConfigurationManager.AppSettings["MongoDb:Username"];
            string host = System.Configuration.ConfigurationManager.AppSettings["MongoDb:Host"];
            string password = System.Configuration.ConfigurationManager.AppSettings["MongoDb:Password"];
            string dbName = System.Configuration.ConfigurationManager.AppSettings["MongoDb:DbName"];
            var settings = new MongoClientSettings()
            {
                Server = new MongoServerAddress(host, 10255),
                UseSsl = true,
                SslSettings = new SslSettings()
            };
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;
            MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
            MongoIdentityEvidence evidence = new PasswordEvidence(password);
            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            Settings = settings;
        }

        protected enum Collection
        {
            RaiderIO,
            Blizzard
        }
    }
}