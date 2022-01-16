using System.Collections.Generic;
using UzsakymuValdymoSistema.Report;
using UzsakymuValdymoSistema.Repositories;
using System;

namespace UzsakymuValdymoSistema
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            while (true)
            {
                controller.ShowMenu();
            }
        }
    }
}
