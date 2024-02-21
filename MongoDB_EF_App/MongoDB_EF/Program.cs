using MongoDataAccess.DataAccess;
using MongoDB.Driver;
using MongoDBApp;
using MongoDataAccess.Models;

//string connectionString = "mongodb://127.0.0.1:27017";
//string databaseName = "simple_db";
//string collectionName = "people";

//// Set up connection
//var client = new MongoClient(connectionString);
//// Select database to interact with
//var db = client.GetDatabase(databaseName);
//// Select collection to interact with
//var collection = db.GetCollection<PersonModel>(collectionName);

//var person = new  PersonModel {FirstName = "Maria", LastName = "Edström"};

//// await for the object to be inserted to database
//await collection.InsertOneAsync(person);

//// await for collection to return every (_) information
//var results = await collection.FindAsync(_ => true);

//foreach (var result in results.ToList())
//{
//    Console.WriteLine($"{result.ID}: {result.FirstName} {result.LastName}");
//}

ChoreDataAccess db  = new ChoreDataAccess();

// await db.CreateUser(new UserModel(){FirstName = "Jack",LastName = "Smith"});

var users = await db.GetAllUsers();

var chore = new ChoreModel()
{
    AssignedTo = users.First(), 
    ChoreText = "Laundry", 
    FrequencyInDays = 5
};

await db.CreateChore(chore);

var chores = await db.GetAllChores();

var newChore = chores.First();
newChore.LastCompleted = DateTime.UtcNow;

await db.CompleteChore(newChore);