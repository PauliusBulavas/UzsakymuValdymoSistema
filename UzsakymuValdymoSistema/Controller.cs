using System;
using System.Collections.Generic;
using System.Text;
using UzsakymuValdymoSistema.Options;

namespace UzsakymuValdymoSistema
{
    public class Controller
    {
        public static void OptionsMenu()
        {           
            Console.WriteLine("Which report do you want to see?");
            Console.WriteLine("[1] - All Client's report");
            Console.WriteLine("[2] - All Order's report");
            Console.WriteLine("[3] - Add/Remove Client");
            Console.WriteLine("[4] - Add/Remove Order");
            Console.WriteLine("[5] - Exit");

            int option = int.Parse(Console.ReadLine()); //error handler reikia 

            switch (option)
            {
                case 1:
                    Console.Clear();
                    DisplayClientsReport.GetClientsReport();
                    break;
                case 2:
                    Console.Clear();
                    DisplayOrdersReport.GetOrdersReport();
                    break;
                case 3:
                    Console.Clear();
                    SelectClientsMenu();
                    break;
                case 4:
                    Console.Clear();
                    SelectOrdersMenu();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("wrong input!");
                    break;
            }
        }

        public static void SelectClientsMenu()
        {
            Console.WriteLine("Do you wish to add or remove a Client?");
            Console.WriteLine("[1] - Add a Client");
            Console.WriteLine("[2] - Remove a Client");
            Console.WriteLine("[3] - Go back");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListEditing.AddClient();
                    Console.Clear();
                    SelectClientsMenu();
                    break;
                case 2:
                    ListEditing.RemoveClient();
                    break;
                default:
                    Console.Clear();
                    OptionsMenu();
                    break;
            }
        }
        public static void SelectOrdersMenu()
        {
            Console.WriteLine("Do you wish to add or remove an Order?");
            Console.WriteLine("[1] - Add an Order");
            Console.WriteLine("[2] - Remove an Order");
            Console.WriteLine("[3] - Go back");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListEditing.AddOrder();                   
                    break;
                case 2:
                    ListEditing.RemoveOrder();
                    break;
                default:
                    Console.Clear();
                    OptionsMenu();
                    break;
            }
        }


    }
}
