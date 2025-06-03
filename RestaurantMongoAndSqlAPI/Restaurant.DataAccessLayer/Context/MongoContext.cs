using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Restaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant.DataAccessLayer.Context
{
    public class MongoContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public MongoContext(IConfiguration configuration)
        {
            var connectionString = "mongodb://localhost:27017";

            var mongoClient = new MongoClient(connectionString);
            _mongoDatabase = mongoClient.GetDatabase("RestaurantMongoAndSqlApiDb");
        }
        public IMongoCollection<About> Abouts => _mongoDatabase.GetCollection<About>("Abouts");
        public IMongoCollection<BookATable> BookATables => _mongoDatabase.GetCollection<BookATable>("BookATables");
        public IMongoCollection<Category> Categories => _mongoDatabase.GetCollection<Category>("Categories");
        public IMongoCollection<ContactDetail> ContactDetails => _mongoDatabase.GetCollection<ContactDetail>("ContactDetails");
        public IMongoCollection<ContactUs> ContactUses => _mongoDatabase.GetCollection<ContactUs>("ContactUses");
        public IMongoCollection<Feature> Features => _mongoDatabase.GetCollection<Feature>("Features");
        public IMongoCollection<Gallery> Galleries => _mongoDatabase.GetCollection<Gallery>("Galleries");
        public IMongoCollection<OurSpecial> OurSpecials => _mongoDatabase.GetCollection<OurSpecial>("OurSpecials");
        public IMongoCollection<Product> Products => _mongoDatabase.GetCollection<Product>("Products");
        public IMongoCollection<Service> Services => _mongoDatabase.GetCollection<Service>("Services");
        public IMongoCollection<Team> Teams => _mongoDatabase.GetCollection<Team>("Teams");
        public IMongoCollection<Testimonial> Testimonials => _mongoDatabase.GetCollection<Testimonial>("Testimonials");
        public IMongoCollection<WhyUs> WhyUses => _mongoDatabase.GetCollection<WhyUs>("WhyUses");

        public IMongoCollection<T>GetCollection<T>(string collectionName)
        {
            return _mongoDatabase.GetCollection<T>(collectionName);
        }
    }
}
