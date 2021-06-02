using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConstructionFirm.Bl.Services
{
    public class ClientService
    {
        public List<Client> Clients;

        public ClientService()
        {
            var json = "";
            using (var sr = new StreamReader("clients.json"))
            {
                json = sr.ReadToEnd();
            }
            
            Clients = JsonConvert.DeserializeObject<List<Client>>(json) ?? new();

            
            
        }

        public void CreateNewUser(Client client)
        {
            if (UserExists(client.UserName)) return;
            Clients.Add(client);
            SaveChanges();
        }

        public bool UserExists(string name)
        {
            return Clients.FirstOrDefault(x => x.UserName == name) != null;
        }

        public Client GetUser(string name)
        {
            return Clients.FirstOrDefault(x => x.UserName == name); 
        }
        
        private void SaveChanges()
        {
            using (var sw = new StreamWriter("clients.json"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(Clients));
            }
        }
    }
}