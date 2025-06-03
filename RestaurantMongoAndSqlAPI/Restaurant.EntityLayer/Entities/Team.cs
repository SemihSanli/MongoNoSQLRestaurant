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
    public class Team:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string TeamFullName { get; set; }
        public string TeamTitle { get; set; }
        public string TeamSocialMedia1 { get; set; }
        public string TeamSocialMedia2 { get; set; }
        public string TeamSocialMedia3 { get; set; }
        public string TeamSocialMedia4 { get; set; }
        public string TeamImageURL { get; set; }
    }
}
