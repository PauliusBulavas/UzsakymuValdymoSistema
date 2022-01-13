using System;
using System.Collections.Generic;
using System.Text;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Options
{
    public class ListEditing
    {
        //reikia perdaryti kad pagal id ieskotu o ne indeksa ir ar gerai pasiemu duomenis is repo???
        public static void AddClient()
        {
            var clientRepository = new ClientRepository();
            List<Client> clients = clientRepository.GetClients();

            int index = 0;

            Console.WriteLine("Current available Clients:");
            foreach (var client in clients)
            {
                Console.WriteLine($"{index} - ID: {client.ClientId} Name: {client.ClientName} Company name: ''{client.ClientCompanyName}'' ");
                index++;
            }
        }
        public static void RemoveClient()
        {
            var clientRepository = new ClientRepository();
            List<Client> clients = clientRepository.GetClients();

            int index = 0;

            Console.WriteLine("Current available Clients:");
            foreach (var client in clients)
            {
                Console.WriteLine($"{index} - ID: {client.ClientId} Name: {client.ClientName} Company name: ''{client.ClientCompanyName}'' ");
            }
        }
        public static void AddOrder() //duomenys apjungti is dvieju listu, order repo turi tik producto id, tad reikia pasiimti ir product repo
        {
            var orederRepository = new OrdersRepository();
            List<Order> orders = orederRepository.GetOrders();

            int index = 0;

            Console.WriteLine("Current available Orders:");
            foreach(var order in orders)
            {
                Console.WriteLine($"{index} - ");
            }
        }
        public static void RemoveOrder()
        {

        }
    }
}
