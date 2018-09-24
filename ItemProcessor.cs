using System;
using System.Threading.Tasks;


namespace tehtäviä
{

    public class ItemProcessor
    {
            ItemRepository repository;

    public ItemProcessor (ItemRepository repo){
        repository = repo;
    }

        public Task<Item> Get (Guid id){
            return repository.Get(id);
        }
        public Task<Item[]> GetAll (){
            return repository.GetAll();
        }
        public Task<Item> Create(NewItem item){
            Item dispencer = new Item();
            dispencer.Name = item.Name;
            dispencer.ItemType =item.ItemType;
            dispencer.OwnerId = item.OwnerId;
            dispencer.CreationTime = DateTime.Now;
            dispencer.Level =1;
            dispencer.itemId = Guid.NewGuid();
            return repository.Create(dispencer);

        }
        public Task<Item> Modify (Guid id, ModifiedItem item){
            return repository.Modify(id, item);
        }
        public Task<Item> Delete (Guid id){
            return repository.Delete(id);
        }
   public async Task<Item[]> GetAllItems(Guid playerId)
        {
              return repository.GetAllItems(playerId);
        }
    }
    }