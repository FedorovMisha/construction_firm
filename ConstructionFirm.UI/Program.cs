using System;
using System.Collections.Generic;
using System.Linq;
using ConstructionFirm.BL;

namespace ConstructionFirm.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = Login();
            
            client.GetOrderPhases(1).ToList().ForEach(x => Console.WriteLine(x));
            
            client.Orders.Last().MakePhase();
            client.Orders.Last().MakePhase();

            Console.WriteLine(client.Orders.Last().IsComplete);
        }

        private static Client Login()
        {
            Console.WriteLine("Введите имя пользователя");
            var userName = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            var password = Console.ReadLine();
            List<IWorker> workers = new List<IWorker>()
            {
                new Worker() {Id = 1, Password = "ssq121s", UserName = "W1"},
                new Worker() {Id = 2, Password = "ssq121s", UserName = "W2"},
                new Worker() {Id = 3, Password = "ssq121s", UserName = "W3"},
                new Worker() {Id = 4, Password = "ssq121s", UserName = "W4"}
            };
            
            Brigade developmentTeam = new Brigade(workers);
            
            Brigade constructionTeam = new Brigade(workers);
            
            Order order = new Order()
            {
                IsComplete = false,
                OrderKey = 1,
                Phases = new List<ConstructionPhase>()
                {
                    new ConstructionPhase(new(){"devTask1", "devTask2"}, developmentTeam){
                        DateStart = DateTime.Now, DateEnd = DateTime.Now.AddMonths(1)
                    },
                    new ConstructionPhase(new(){"constructionTask1", "constructionTask2"}, constructionTeam)
                    {
                        DateStart = DateTime.Now, DateEnd = DateTime.Now.AddMonths(1)
                    },
                }
            };

            var client = new Client()
            {
                UserName = "Client",
                Password = "Password",
                Id = 5,
            };
            client.Orders.Add(order);
            return client;
        }
    }
}