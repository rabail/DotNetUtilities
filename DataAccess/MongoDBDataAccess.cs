using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataAccess
{
    public class MongoDBDataAccess
    {
        IMongoDatabase database;

        public MongoDBDataAccess(string _connectionString, string _certificatePath = null, string _certificatePassword = null)
        {
            InitConnection(_connectionString, _certificatePath, _certificatePassword);
        }

        private void InitConnection(string _connectionString, string _certificatePath, string _certificatePassword)
        {
            try
            {
                var mongoUrl = MongoUrl.Create(_connectionString);
                X509Certificate2 sslCert;

                MongoClientSettings settings = new MongoClientSettings
                {
                    Server = mongoUrl.Server
                };

                if (mongoUrl.UseSsl && !String.IsNullOrEmpty(_certificatePath) && !String.IsNullOrEmpty(_certificatePassword))
                {
                    sslCert = new X509Certificate2(_certificatePath, _certificatePassword, X509KeyStorageFlags.MachineKeySet);
                    settings.UseSsl = true;
                    settings.SslSettings = new SslSettings
                    {
                        ClientCertificates = new[] { sslCert }
                    };
                    settings.VerifySslCertificate = false;
                }

                MongoClient client = new MongoClient(settings);
                database = client.GetDatabase(mongoUrl.DatabaseName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IMongoDatabase GetDatabaseHandle()
        {
            return database;
        }
    }
}
