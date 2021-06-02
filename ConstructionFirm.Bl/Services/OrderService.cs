using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConstructionFirm.Bl.Services
{
    public class OrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            var ordersJson = "";
         
            
            using (var sr = new StreamReader("orders.json"))
            {
                ordersJson = sr.ReadToEnd();
            }
            
            _orders = JsonConvert.DeserializeObject<List<Order>>(ordersJson) ?? new();
        }

        public void CreateOrder(Order order)
        {
            _orders.Add(order);
            SaveChanges();
        }

        public Order GetOrder(string id)
        {
            return _orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetAll()
        {
            return _orders;
        }

        public List<Order> GetUserOrders(string userId)
        {
            return _orders.Where(x => x.UserId == userId).ToList();
        }

        public void UpdateOrder(Order order)
        {
            var orderToChange = _orders.FirstOrDefault(x => x.Id == order.Id);
            
            if(orderToChange == null) return;

            orderToChange.Materials = order.Materials;
            orderToChange.Start = order.Start;
            orderToChange.End = order.End;
            orderToChange.Phases = order.Phases;
            SaveChanges();
        }
        
        private void SaveChanges()
        {
            var json = JsonConvert.SerializeObject(_orders);

            using (var sw = new StreamWriter("orders.json"))
            {
                sw.WriteLine(json);
            }
        }
        
    }
}