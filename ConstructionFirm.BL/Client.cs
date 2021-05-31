using System.Collections.Generic;
using System.Linq;

namespace ConstructionFirm.BL
{
    public class Client : User
    {
        public List<Order> Orders { get; set; } = new();

        public string[] GetOrderPhases(int key)
        {
            return Orders.FirstOrDefault(x => x.OrderKey == key)?.GetPhasesStrings();
        }
    }
}