using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ConstructionFirm.Bl
{
    public class Order
    {
        public string Id { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
        
        public string UserId { get; set; }
        
        public List<Material> Materials { get; set; }
        
        public List<Phase> Phases { get; set; }
        
        public bool IsComplete { get; set; }

        public Order()
        {
            Id = Guid.NewGuid().ToString();
            Phases = new();
            Materials = new();
        }

        public override string ToString()
        {
            return Id;
        }

        public decimal GetMaterialPrice()
        {
            return Materials.Sum(x => x.Price);
        }
    }
}