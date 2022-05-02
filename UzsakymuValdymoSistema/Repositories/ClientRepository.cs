using System;
using System.Collections.Generic;
using System.Linq;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Options;

namespace UzsakymuValdymoSistema.Repositories
{
    public class ClientRepository
    {
        private readonly List<Client> clients = new List<Client>();

        public ClientRepository()
        {
            string fileName = FileReaderService.GetPathToResource("ClientRepository.txt");
            clients = new FileReaderService().Import<Client>(fileName);
        }

        public List<Client> GetClients() => clients;

        public Client GetClientsById(int clientId)
        {
            var actualClient = clients.FirstOrDefault(x => x.Id == clientId);

            return actualClient;
        }

        public void AddClient(Client client)
        {
            client.Id = clients.LastOrDefault().Id + 1;
            clients.Add(client);
        }

        public bool RemoveClient(int id)
        {
            return clients.Remove(GetClientsById(id));
        }

        public void PrintClients()
        {
            Console.WriteLine("All Current Clients:\n");
            foreach (var client in clients)
            {
                //Console.WriteLine($"ID: {client.Id}, Name: {client.Name}, Company name: \"{client.CompanyName}\" ");
                var formated = string.Format("Id - {0, -3} Name - {1, -10} Company Name - \"{2,-5}\"", client.Id, client.Name, client.CompanyName);
                Console.WriteLine(formated);
            }

            Console.WriteLine();
        }
    }
}