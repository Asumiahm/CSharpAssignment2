using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace pokedex.Models
{
    public class Pokemon
    {
       [BsonId]
       [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Ability { get; set; } = string.Empty;

        public int Level { get; set; }
    }
}