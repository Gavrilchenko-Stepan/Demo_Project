using System.Collections.Generic;

namespace DemoLib.Models
{
    public interface IClientsModel
    {
        List<Client> ReadAllClients();

        int GetClientsCount();
        void AddClient(Client client);
        bool RemoveClient(int clientId);
        void UpdateClient(Client client);

        void AddOrderRecord(int clientId, OrderRecord record);
        bool RemoveOrderRecord(int clientId, OrderRecord record);
        void UpdateOrderRecord(int clientId, OrderRecord oldRecord, OrderRecord newRecord);
    }
}
