using MongoDataAccess.Models;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess;

public class ChoreDataAccess
{
    private const string ConnectionString = "mongodb+srv://Admin:admin@mongodbcloud.nshrp2i.mongodb.net/";
    private const string DatabaseName = "choreDb";
    private const string ChoreCollection = "chore_chart";
    private const string UserCollection = "users";
    private const string ChoreHistoryCollection = "chore_history";

    private IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(collection);
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        var usersCollection = ConnectToMongo<UserModel>(UserCollection);
        var results = await usersCollection.FindAsync(_ => true);
        return results.ToList();
    }

    public async Task<List<ChoreModel>> GetAllChores()
    {
        var choreCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
        var results = await choreCollection.FindAsync(_ => true);
        return results.ToList();
    }

    public async Task<List<ChoreModel>> GetAllChoresForAUser(UserModel user)
    {
        var choreCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
        var results = await choreCollection.FindAsync(c => c.AssignedTo.ID == user.ID);
        return results.ToList();
    }

    public Task CreateUser(UserModel user)
    {
        var usersCollection = ConnectToMongo<UserModel>(UserCollection);
        return usersCollection.InsertOneAsync(user);
    }

    public Task CreateChore(ChoreModel chore)
    {
        var choreCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
        return choreCollection.InsertOneAsync(chore);
    }

    public Task UpdateChore(ChoreModel chore)
    {
        var choreCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
        var filter = Builders<ChoreModel>.Filter.Eq("ID", chore.ID);
        return choreCollection.ReplaceOneAsync(filter, chore, new ReplaceOptions { IsUpsert = true });
    }

    public Task DeleteChore(ChoreModel chore)
    {
        var choreCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
        return choreCollection.DeleteOneAsync(c => c.ID == chore.ID);
    }

    public async Task CompleteChore(ChoreModel chore)
    {
        //var choreCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
        //var filter = Builders<ChoreModel>.Filter.Eq("ID", chore.ID);
        //await choresCollection.ReplaceOneAsync(filter, chore);

        //var choreHistoryCollection = ConnectToMongo<ChoreHistoryModel>(ChoreHistoryCollection);
        //await choresHistoryCollection.InsertOneAsync(new ChoreHistoryModel(chore));

        var client = new MongoClient(ConnectionString);
        using var session = await client.StartSessionAsync();

        session.StartTransaction();

        try
        {
            var db = client.GetDatabase(DatabaseName);
            var choresCollection = db.GetCollection<ChoreModel>(ChoreCollection);
            var filter = Builders<ChoreModel>.Filter.Eq("ID", chore.ID);
            await choresCollection.ReplaceOneAsync(filter, chore);

            var choreHistoryCollection = db.GetCollection<ChoreHistoryModel>(ChoreHistoryCollection);
            await choreHistoryCollection.InsertOneAsync(new ChoreHistoryModel(chore));

            await session.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            await session.AbortTransactionAsync();
            Console.WriteLine(e.Message);
        }
    }
}