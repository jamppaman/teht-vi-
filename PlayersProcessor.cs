using System;
using System.Threading.Tasks;

namespace tehtäviä {
    public class PlayerProcessor {
    IRepository repository;

    public PlayerProcessor (IRepository repo){
        repository = repo;
    }

        public Task<Player> Get (Guid id){
            return repository.GetPlayer(id);
        }
        public Task<Player[]> GetAll (){
            return repository.GetAllPlayers();
        }
        public Task<Player> Create(NewPlayer player){
            Player tommie = new Player();
            tommie.Name = player.Name;
            tommie.CreationTime = DateTime.Now;
            tommie.IsBanned = false;
            tommie.Score =0;
            tommie.playerId = Guid.NewGuid();
            return repository.CreatePlayer(tommie);

        }
        public Task<Item> updateItem (Guid id, Item item){
            return repository.UpdateItem(id, item);
        }

        internal Task<Player> Modifyplayer(Guid id, ModifiedPlayer player)
        {
            throw new NotImplementedException();
        }

        public Task<Player> Delete (Guid id){
            return repository.DeletePlayer(id);
        }
    }
}