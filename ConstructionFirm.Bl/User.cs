using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using ConstructionFirm.Bl.Services;

namespace ConstructionFirm.Bl
{
    public class User
    {
        public string Id { get; set; }
        
        public string UserName { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

    public class Client : User
    {
        [JsonIgnore]
        public List<Order> Orders { get; set; }
        
        [JsonIgnore]
        public OrderService OrderService { get; set; }

        public Client()
        {
            
        }
        public Client(OrderService orderService)
        {
            OrderService = orderService;
            Load();
        }

        public void MakeNewOrder(DateTime start, DateTime end,List<Material> materials, params Phase[] phases)
        {
            OrderService.CreateOrder(new Order()
            {
                Start = start,
                End = end,
                Materials = materials,
                Phases = phases.ToList()
            });
            Load();
        }

        public void Load()
        {
            Orders = OrderService.GetUserOrders(this.Id) ?? new();
        }
        
        public List<Order> GetMyOrders() => Orders;

        public void AddOrder(Order order)
        {
            Orders.Add(order);
            OrderService.CreateOrder(order);
        }

        public void SetOrderAsComplete(string orderId)
        {
            var orderToChange = Orders.FirstOrDefault(x => x.Id == orderId);
            if(orderToChange == null)return;
            orderToChange.IsComplete = true;
            OrderService.UpdateOrder(orderToChange);
        }

        private void UpdateOrders()
        {
            Orders = OrderService.GetUserOrders(this.Id);
        }
    }
}