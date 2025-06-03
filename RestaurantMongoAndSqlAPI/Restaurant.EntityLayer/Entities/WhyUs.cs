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
    public class WhyUs:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string WhyUsTitle { get; set; }
        public string WhyUsDetail { get; set; }
    }
}
