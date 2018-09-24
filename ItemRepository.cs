using System;
using System.Threading.Tasks;

namespace tehtäviä
{
public interface ItemRepository
{
    Task<Item> Get(Guid id);
    Task<Item[]> GetAll();
    Task<Item> Create(Item item);
    Task<Item> Modify(Guid id, ModifiedItem item);

    Task<Item> GetAllItems(Guid playerId);
    Task<Item> Delete(Guid id);
}
}