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
            Console.WriteLine($"[4] - Add/Remove Client");
            Console.WriteLine($"[5] - Add/Remove Order");

            int option = int.Parse(Console.ReadLine()); //error handler reikia 

            switch (option)
            {
                case 1:
                    DisplayClientsReport.GetClientsReport();
                    break;
                case 2:
                    DisplayOrdersReport.GetOrdersReport();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("wrong input!");
                    break;
            }
        }
    }
}
