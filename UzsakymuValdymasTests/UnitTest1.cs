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
            string name = "Tomas";
            //act
            var actualRessult = clientRepository.GetClients(3);
            //assert
            Assert.AreEqual(name, actualRessult.ClientName);
        }

        [Test]
        public void TestingGetProductsById()
        {
            var productRepostiory = new ProductRepository();
            string name = "Tin";

            var acctualRessult = productRepostiory.GetProducts(4);

            Assert.AreEqual(name, acctualRessult.ProductName);
        }

        [Test]
        public void TestingGetordersById()
        {
            var ordersRepository = new OrdersRepository();
            int clientId = 3;

            var acctualResult = ordersRepository.GetOrders(5);

            Assert.AreEqual(clientId, acctualResult.ClientId);
        }
    }
}