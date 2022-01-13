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
            Console.WriteLine($"[1] - All Client's report");
            Console.WriteLine($"[2] - All Order's report");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    DisplayClientsReport.GetClientsReport();
                    break;
                case 2:
                    DisplayOrdersReport.GetOrdersReport();
                    break;
                default:
                    Console.WriteLine("wrong input!");
                    break;
            }
        }
    }
}
