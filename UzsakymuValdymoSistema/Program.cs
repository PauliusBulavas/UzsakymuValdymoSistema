namespace UzsakymuValdymoSistema
{
    internal class Program
    {
        private static void Main()
        {
            var controller = new Controller();

            while (true)
            {
                controller.ShowMenu();
            }
        }
    }
}