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
    public class OurSpecial:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string OurSpecialColumnTitle { get; set; }
        public string OurSpecialTitle { get; set; }
        public string OurSpecialContent { get; set; }
        public string OurSpecialImageURL { get; set; }
    }
}
