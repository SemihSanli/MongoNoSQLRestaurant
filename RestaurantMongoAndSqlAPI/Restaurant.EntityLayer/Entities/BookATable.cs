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
    public class BookATable:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string BookFullName { get; set; }
        public string BookEmail { get; set; }
        public string BookPhone { get; set; }
        public DateTime BookDate { get; set; }
        public int BookPersonCount { get; set; }
        public string BookMessage { get; set; }
    }
}
