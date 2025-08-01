﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.Dtos.TeamDtos
{
    public class CreateTeamDto
    {
        

        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> SocialMediaIds { get; set; }
    }
}
