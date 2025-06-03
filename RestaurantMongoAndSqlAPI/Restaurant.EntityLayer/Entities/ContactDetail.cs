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
    public class ContactDetail:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ContactDetailLocation { get; set; }
        public string ContactDetailLocationMapURL { get; set; }
        public string ContactDetailOpenHours { get; set; }
        public string ContactDetailCallUs { get; set; }
        public string ContactDetailEmailUs { get; set; }
    }
}
