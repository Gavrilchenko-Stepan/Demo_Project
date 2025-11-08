using System.Collections.Generic;
using System.Linq;

namespace DemoLib.Models
{
    public class MemoryClientsModel : IClientsModel
    {
        private List<Client> allClients_ = new List<Client>();  

        public MemoryClientsModel()
        {
            Client c1 = new Client(1);
            c1.Name = "Просто Валера";
            c1.Description = "Это самый совершенный клиент из всех возможных";
            c1.Phone = "777";
            c1.Mail = "666@sobaka.ru";
            c1.ImagePath = "../../../Resources/img/Valera.jpg";

            c1.order.AddRecord(new OrderRecord 
            { NameProduct = "Мешок цемента", 
                Count = 1, Price = 10000, 
                SaleDate = new System.DateTime(2025, 10, 1) 
            });

            c1.order.AddRecord(new OrderRecord
            {
                NameProduct = "Саморезы",
                Count = 100,
                Price = 100,
                SaleDate = new System.DateTime(2025, 10, 2)
            });


            Client c2 = new Client(2);
            c2.Name = "ОАО ЕПРСТЕЙКА";
            c2.Description = "Похуже, чем Валера";
            c2.Phone = "666";
            c2.Mail = "777@sobaka.ru";
            c2.ImagePath = "../../../Resources/img/prsteyka.jpg";

            allClients_.Add(c1);
            allClients_.Add(c2);
        }
        public List<Client> ReadAllClients()
        {
            return allClients_;
        }

        public int GetClientsCount()
        {
            return allClients_.Count;
        }

        public void AddClient(Client client)
        {
            int nextId = allClients_.Count > 0 ? allClients_.Max(c => c.ID) + 1 : 1;

            var newClient = new Client(nextId)
            {
                Name = client.Name,
                Description = client.Description,
                Phone = client.Phone,
                Mail = client.Mail,
                ImagePath = client.ImagePath
            };
            allClients_.Add(newClient);
        }

        public bool RemoveClient(int clientId)
        {
            var clientToRemove = allClients_.FirstOrDefault(c => c.ID == clientId);
            if (clientToRemove != null)
            {
                return allClients_.Remove(clientToRemove);
            }
            return false;
        }

        public void UpdateClient(Client client)
        {
            var existingClient = allClients_.FirstOrDefault(c => c.ID == client.ID);
            if (existingClient != null)
            {
                existingClient.Name = client.Name;
                existingClient.Description = client.Description;
                existingClient.Phone = client.Phone;
                existingClient.Mail = client.Mail;
                existingClient.ImagePath = client.ImagePath;
            }
        }

        public void AddOrderRecord(int clientId, OrderRecord record)
        {
            var client = allClients_.FirstOrDefault(c => c.ID == clientId);
            if (client != null)
            {
                client.order.AddRecord(record);
            }
        }

        public bool RemoveOrderRecord(int clientId, OrderRecord record)
        {
            var client = allClients_.FirstOrDefault(c => c.ID == clientId);
            if (client != null)
            {
                return client.order.RemoveRecord(record);
            }
            return false;
        }

        public void UpdateOrderRecord(int clientId, OrderRecord oldRecord, OrderRecord newRecord)
        {
            var client = allClients_.FirstOrDefault(c => c.ID == clientId);
            if (client != null)
            {
                // Удаляем старую запись и добавляем новую
                client.order.RemoveRecord(oldRecord);
                client.order.AddRecord(newRecord);
            }
        }
    }
}
