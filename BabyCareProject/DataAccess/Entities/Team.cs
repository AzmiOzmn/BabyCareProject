using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.DataAccess.Entities
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TeamId { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> SocialMediaIds { get; set; }
    }
}
