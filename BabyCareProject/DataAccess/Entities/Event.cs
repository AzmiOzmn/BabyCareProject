using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.DataAccess.Entities
{
    public class Event
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }
        public string Date { get; set; }
        public DateTime StartTime  { get; set; }
        public DateTime EndTime  { get; set; }
        public string Location  { get; set; }
        public string Title  { get; set; }
        public string Description  { get; set; }
        public string ImageUrl  { get; set; }
    }
}
