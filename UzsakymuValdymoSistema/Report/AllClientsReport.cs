using System;
using System.Collections.Generic;
using System.Text;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Report
{
    class AllClientsReport
    {
        private ClientRepository _clientRepository;
        private OrdersRepository _ordersRepository;

        public AllClientsReport(ClientRepository clientRepository, OrdersRepository ordersRepository)
        {
            _clientRepository = clientRepository;
            _ordersRepository = ordersRepository;
        }

        public List<ReportItemClients> GetAllClients()
        {
            List<Client> clients                = _clientRepository.GetClients();
            List<ReportItemClients> clientList  = new List<ReportItemClients>();

            foreach (var client in clients)
            {
                var report = new ReportItemClients();
                report.ClientId             = client.ClientId;
                report.ClientName           = client.ClientName;
                report.ClientCompanyName    = client.ClientCompanyName;

                clientList.Add(report);
            }

            return clientList;
        }
    }
}
