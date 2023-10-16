using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using modelos_webdev.Models;
using System.ComponentModel.DataAnnotations;

namespace modelos_webdev.Models
{
    public class Card
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        public bool Status { get; set; } = false;

        public string? Description { get; set; }
    }
}