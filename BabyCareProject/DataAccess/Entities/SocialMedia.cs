using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.DataAccess.Entities
{
    public class SocialMedia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SocialMediaId { get; set; }

        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}
