using NUnit.Framework;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymasTests
{
    public class Tests
    {
        [Test]
        public void TestingGetClientsById()
        {
            //arrange
            var clientRepository = new ClientRepository();
            string name = "Andrius";
            //act
            var actualRessult = clientRepository.GetClientsById(3);
            //assert
            Assert.AreEqual(name, actualRessult.Name);
        }

        [Test]
        public void TestingGetProductsById()
        {
            var productRepostiory = new ProductRepository();
            string name = "Tin";

            var acctualRessult = productRepostiory.GetProductsById(4);

            Assert.AreEqual(name, acctualRessult.Name);
        }

        [Test]
        public void TestingGetordersById()
        {
            var ordersRepository = new OrdersRepository();
            int clientId = 3;

            var acctualResult = ordersRepository.GetOrdersById(5);

            Assert.AreEqual(clientId, acctualResult.ClientId);
        }
    }
}