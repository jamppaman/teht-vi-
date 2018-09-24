using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace tehtäviä
{
        [Route("api/players/{playerId}/items")]
    public class ItemController
    {
        
        ItemProcessor prosessor;
        public ItemController( ItemProcessor itempro){
            prosessor = itempro;
        }
        [HttpGet("id")]
        public Task<Item> Get (Guid id) {
            return prosessor.Get(id);
         }
         [HttpGet]
        public Task<Item[]> GetAll(){
            return prosessor.GetAll();
        }
        [HttpPost]
        public Task<Item> Create ([FromBody]NewItem item){
            return prosessor.Create(item);
        }
        [HttpPatch("id")]
        public Task<Item> Modify (Guid id,[FromBody] ModifiedItem item){
            return prosessor.Modify(id,item);
        }
        [HttpDelete("id)")]
        public Task<Item> Delete (Guid id){
            return prosessor.Delete(id);
        }
    }
}