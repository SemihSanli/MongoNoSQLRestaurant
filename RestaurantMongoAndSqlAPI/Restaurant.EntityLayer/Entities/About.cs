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
    public class About: IBaseEntity //Baseentity üzerinden miras alarak tüm entityler için bir generic yapı oluşturdum
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string AboutTitle { get; set; }
        public string AboutSubTitle { get; set; }
        public string AboutArticle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutImageURL { get; set; }

       
    }
}
