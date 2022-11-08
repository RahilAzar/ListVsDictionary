using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Entity
    {
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public DateTime FetchDate { get; set; }
    
        public Entity()
        { }
        public Entity(Guid id,string name, string description, Double price, DateTime fetchDate)
        {
            EntityId = id;
            Name = name;
            Description = description;
            Price = price;
            FetchDate = fetchDate;
        }
    }
}
