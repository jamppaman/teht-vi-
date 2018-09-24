using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
//using game_server.Players;
using tehtäviä;

namespace game_server.Repositories
{
    public class MongoDbRepository : IRepository
     {
        private readonly IMongoCollection<Player> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;


        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase("Game");
            _collection = database.GetCollection<Player>("players");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("players");
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            await _collection.InsertOneAsync(player);
            return player;
        }

        public async Task<Player[]> GetAllPlayers()
        {
            List<Player> players = await _collection.Find(new BsonDocument()).ToListAsync();
            return players.ToArray();
        }

        public Task<Player> GetPlayer(Guid playerId)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", playerId);
            return _collection.Find(filter).FirstAsync();
        }

        // public async Task<Player[]> GetBetweenLevelsAsync(int minLevel, int maxLevel)
        // {
        //     FilterDefinition<Player> filter = Builders<Player>.Filter.Gte("Level", 18) & Builders<Player>.Filter.Lte("Level", 30);
        //     List<Player> players = await _collection.Find(filter).ToListAsync();
        //     return players.ToArray();
        // }


        // public Task<Player> IncreasePlayerScoreAndRemoveItem(Guid playerId, Guid itemId, int score)
        // {
        //     var pull = Builders<Player>.Update.PullFilter(p => p.Items, i => i.Id == itemId);
        //     var inc = Builders<Player>.Update.Inc(p => p.Score, score);
        //     var update = Builders<Player>.Update.Combine(pull, inc);
        //     var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);

        //     return _collection.FindOneAndUpdateAsync(filter, update);
        // }

        public async Task<Player> UpdatePlayer(Player player)
        {
            var filter = Builders<Player>.Filter.Eq("_id", player.playerId);
            await _collection.ReplaceOneAsync(filter, player);
            return player;
        }

        // public async Task<Player[]> GetAllSortedByScoreDescending()
        // {
        //     SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending(p => p.Score);
        //     List<Player> players = await _collection.Find(new BsonDocument()).Sort(sortDef).ToListAsync();
        //     return players.ToArray();
        // }

        // public async Task<Player> IncrementPlayerScore(string id, int increment)
        // {
        //     var filter = Builders<Player>.Filter.Eq("_id", id);
        //     var incrementScoreUpdate = Builders<Player>.Update.Inc(p => p.Score, increment);
        //     var options = new FindOneAndUpdateOptions<Player>()
        //     {
        //         ReturnDocument = ReturnDocument.After
        //     };
        //     Player player = await _collection.FindOneAndUpdateAsync(filter, incrementScoreUpdate, options);
        //     return player;
        // }

        public Task<Player> DeletePlayer(Guid playerId)
        {
            var filter = Builders<Player>.Filter.Eq("id",playerId);
            _collection.DeleteOne(filter);
            return null;
        }

        public async Task<Item> CreateItem(Guid playerId, Item item)
        {
            var temp = GetPlayer(playerId);
            temp.Result.itemList.Add(item);
            return item;
        }

        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            var temp = GetPlayer(playerId);
            foreach(var itemvar in temp.Result.itemList)
            {
                if (itemvar.itemId == itemId){
                    return itemvar;
                }
            }
            return null;
        }

        public async Task<Item[]> GetAllItems(Guid playerId)
        {
           return GetPlayer(playerId).Result.itemList.ToArray();
        }

        public async Task<Item> UpdateItem(Guid playerId, Item item)
        {
            
            var temp = GetPlayer(playerId);
            foreach(var itemvar in temp.Result.itemList){
              if(itemvar.itemId == itemvar.itemId){
                temp.Result.itemList.Remove(itemvar);
                temp.Result.itemList.Add(itemvar);
                return item;
              }
            }
            return null;
        }

        public async Task<Item> DeleteItem(Guid playerId, Item item)
        {
                 {
            
            var temp = GetPlayer(playerId);
            foreach(var itemvar in temp.Result.itemList){
              if(itemvar.itemId == itemvar.itemId){
                  temp.Result.itemList.Remove(itemvar);
                  return itemvar;
              }
            }
            return null;
            }
        }
    }
}