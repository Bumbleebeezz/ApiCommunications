using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBApp;

public class PersonModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}