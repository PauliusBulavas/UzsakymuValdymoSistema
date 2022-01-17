using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using UzsakymuValdymoSistema.Models;

namespace UzsakymuValdymoSistema.Repositories
{
    public class ClientRepository
    {
        private List<Client> clients = new List<Client>();

        //public ClientRepository()
        //{
        //    // client id -- client name -- client company name
        //    clients.Add(new Client(1, "Jonas",   "UAB Lydimo darbai"));
        //    clients.Add(new Client(2, "Petras",  "UAB China Trade"));
        //    clients.Add(new Client(3, "Tomas",   "UAB Kalvis"));
        //    clients.Add(new Client(4, "Andrius", "UAB Smeltlita"));
        //}

        public List<Client> GetClients() => clients;

        public Client GetClientsById(int clientId)
        {
            var actualClient = clients.FirstOrDefault(x => x.ClientId == clientId);

            return actualClient;
        }

        public void AddClient(Client client)              //prideda klienta visa sarasa perziurejus ir prie auksciausio id prideju 1, galima butu skirti unikalius id pagal guid arba parasyti unique id generatoriu kazkoki? tas pats ir kitose repo
        {
           client.ClientId = clients.LastOrDefault().ClientId + 1;
           clients.Add(client);
        }

        public bool RemoveClient(int id)                    //pagal id suranda klienta kuri reikia istrinti. tas pats ir kitose repo
        {
            return clients.Remove(GetClientsById(id));
        }

        public ClientRepository()
        {
            string fileName = "C:\\Users\\pauli\\Documents\\GitHub\\UzsakymuValdymoSistema\\Data\\ClientRepository.csv";
            string[] linesInFile = File.ReadAllLines(fileName);
            linesInFile = linesInFile.Skip(1).ToArray();


            foreach (string line in linesInFile)
            {
                string[] rows = line.Split(',');

                var client = new Client();
                client.ClientId          = Convert.ToInt32(rows[0]);
                client.ClientName        = rows[1];
                client.ClientCompanyName = rows[2];

                clients.Add(client);
            }
        }
    }
}
