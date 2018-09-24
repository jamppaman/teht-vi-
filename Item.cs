using System;
using System.ComponentModel.DataAnnotations;

namespace tehtäviä
{
    public class Item
    {
    public Guid itemId { get; set; }
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public int Level { get; set; }
    public int ItemType {get; set;}

    public DateTime CreationTime { get; set; }
}
    
}
