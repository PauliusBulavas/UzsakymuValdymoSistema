using System.Collections.Generic;
using System.Linq;
using UzsakymuValdymoSistema.Models;

namespace UzsakymuValdymoSistema.Repositories
{
    class ClientRepository
    {
        private List<Client> clients = new List<Client>();

        public ClientRepository()
        {
            // clientid - clientName - clientCompanyName
            clients.Add(new Client(1, "Jonas", "UAB Lydimo darbai"));
            clients.Add(new Client(2, "Petras", "UAB China Trade"));
            clients.Add(new Client(3, "Tomas", "UAB Kalvis"));
            clients.Add(new Client(4, "Andrius", "UAB Smeltlita"));
        }

        public List<Client> GetClients() => clients;

        public Client GetClients(int clientId)
        {
            var actualClient = clients.FirstOrDefault(x => x.ClientId == clientId);

            return actualClient;
        }
    }
}
