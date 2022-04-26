using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FamilyTrackerAPI.MongoDB.Entities;

public class FamilyMemberEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Picture { get; set; } = null!;
    public string Location { get; set; } = null!;
}