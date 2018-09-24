using System;
using System.Collections.Generic;

namespace tehtäviä
{
  public class Player
{
    public Guid playerId { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public bool IsBanned { get; set; }
    public DateTime CreationTime { get; set; }
    public List<Item> itemList =new List<Item>();
    
}
}