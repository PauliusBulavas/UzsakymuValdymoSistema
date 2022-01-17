using System.Collections.Generic;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Report
{
    class AllClientsReport
    {
        private ClientRepository _clientRepository;

        public AllClientsReport(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<ReportItemClients> GetAllClients() //nereikalinga class bei metodas, uztenka tiesiog visus isprintinti, kadangi nieko is kitu repo neriekia
        {
            List<Client> clients               = _clientRepository.GetClients();
            List<ReportItemClients> clientList = new List<ReportItemClients>();

            foreach (var client in clients)
            {
                var report = new ReportItemClients();
                report.ClientId          = client.ClientId;
                report.ClientName        = client.ClientName;
                report.ClientCompanyName = client.ClientCompanyName;

                clientList.Add(report);
            }

            return clientList;
        }
    }
}
