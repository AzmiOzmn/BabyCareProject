using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.DataAccess.Entities
{
    public class Navbar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string NavbarId { get; set; }

        public string Location { get; set; }
        public string Email { get; set; }
        public string SocialMediaUrl { get; set; }
        public string SocialMediaUrl1 { get; set; }
        public string SocialMediaUrl2 { get; set; }
        public string SocialMediaUrl3 { get; set; }
    }
}
