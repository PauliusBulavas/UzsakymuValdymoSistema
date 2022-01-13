using System;
using System.Collections.Generic;
using System.Text;
using UzsakymuValdymoSistema.Report;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Options
{
    public class DisplayClientsReport
    {
        public static void GetClientsReport()
        {
            var clientRepository  = new ClientRepository();
            var ordersRepository  = new OrdersRepository();
            var productRepository = new ProductRepository();

            var allClientsReport = new AllClientsReport(clientRepository, ordersRepository);


            List<ReportItemClients> allClients = allClientsReport.GetAllClients();

            Console.WriteLine("All Clients report:");
            foreach (var item in allClients)
            {
                Console.WriteLine($"Client Id:{item.ClientId} -- Name: {item.ClientName} Company: ''{item.ClientCompanyName}''.");
            }

        }
    }
}

