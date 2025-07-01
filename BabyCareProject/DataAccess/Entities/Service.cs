using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.DataAccess.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string ServiceId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
    }
}
