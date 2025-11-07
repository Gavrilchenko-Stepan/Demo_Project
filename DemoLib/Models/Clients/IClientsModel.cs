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
    }
}
