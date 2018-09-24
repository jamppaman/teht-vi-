using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tehtäviä
{
    public class InMemoryRepository :IRepository
    {
        public List<Player> playerList =new List<Player>();

        public async Task<Player> Create(Player player){
           playerList.Add(player);
           return player; 
        }

        public Task<Item> CreateItem(Guid playerId, Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Player> CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> Delete(Guid id){
            foreach(var playervar in playerList){
                playerList.Remove(playervar);
                return playervar;
            }
            return null;
        }

        public Task<Item> DeleteItem(Guid playerId, Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Player> DeletePlayer(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> Get(Guid id){
            foreach(var playervar in playerList){
                if(playervar.Id == id){
                return playervar;
                }
            }
            return null;
        }
        public async Task<Player[]> GetAllPlayers()
        {
            return playerList.ToArray();
        }

        public Task<Item[]> GetAllItems(Guid playerId, Guid itemId)
        {
            return itemList.ToArray();
        }

        public Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetPlayer(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer player){
            foreach(var playervar in playerList){
               if(playervar.Id == id){
                   playervar.Score = player.Score;
                return playervar;
                }
            }
            return null;
        }

        public Task<Item> UpdateItem(Guid playerId, Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Player> UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }
    }
}