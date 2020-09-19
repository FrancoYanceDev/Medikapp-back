
using System.IO;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace backend.Service{

    public class ConnectionService{

        protected MongoClient client;
        private static IConfiguration configuration{get; set;}
        public ConnectionService(){
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configuration = builder.Build();
            client = new MongoClient(configuration.GetConnectionString("public"));
        }

    }
}