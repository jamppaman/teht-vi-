using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace tehtäviä {
    [Route("api/players")]
    public class PlayersController : Controller {

        PlayerProcessor prosessor;
        public PlayersController( PlayerProcessor plapro){
            prosessor = plapro;
        }
        [HttpGet("id")]
        public Task<Player> Get (Guid id) {
            return prosessor.Get(id);
         }
         [HttpGet]
        public Task<Player[]> GetAll(){
            return prosessor.GetAll();
        }
        [HttpPost]
        public Task<Player> Create ([FromBody]NewPlayer player){
            return prosessor.Create(player);
        }
        [HttpPatch("id")]
        public Task<Player> Modifyplayer (Guid id,[FromBody] ModifiedPlayer player){
            return prosessor.Modifyplayer(id,player);
        }
        [HttpDelete("id)")]
        public Task<Player> Delete (Guid id){
            return prosessor.Delete(id);
        }
    }
}