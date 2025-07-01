using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.DataAccess.Entities
{
    public class Hero
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string HeroId { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string ImageUrl { get; set; }
    }
}
