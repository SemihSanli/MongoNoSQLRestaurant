using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Restaurant.EntityLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EntityLayer.Entities
{
    public class Service:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ServiceTitle { get; set; }
        public int ServicePrice { get; set; }
        public string ServiceSubTitle { get; set; }
        public string ServiceArticle { get; set; }
        public string ServiceMinDescription { get; set; }
        public string ServiceImageURL { get; set; }
    }
}
