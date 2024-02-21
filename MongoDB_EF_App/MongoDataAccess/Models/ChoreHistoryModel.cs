using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAccess.Models;

public class ChoreHistoryModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ID { get; set; }
    public string ChoreID { get; set; }
    public string ChoreText { get; set;}
    public DateTime DateCompleted { get; set; }
    public UserModel WhoCompleted { get; set; }

    public ChoreHistoryModel()
    {
        
    }

    public ChoreHistoryModel(ChoreModel chore)
    {
        ChoreID = chore.ID;
        DateCompleted = chore.LastCompleted ?? DateTime.Now;
        WhoCompleted = chore.AssignedTo;
        ChoreText = chore.ChoreText;
    }
}