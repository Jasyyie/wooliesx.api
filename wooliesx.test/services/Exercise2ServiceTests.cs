using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using wooliesx.service.services;
using wooliesx.model.models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

namespace wooliesx.test.services
{
    /// <summary>
    /// service test Exercise 2
    /// </summary>
    [TestClass]
    public class Exercise2ServiceTests
    {
        const string jsonResponse = "[{\"name\":\"Test Product A\",\"price\":99.99,\"quantity\":0.0},{\"name\":\"Test Product B\",\"price\":101.99,\"quantity\":0.0},{\"name\":\"Test Product C\",\"price\":10.99,\"quantity\":0.0},{\"name\":\"Test Product D\",\"price\":5.0,\"quantity\":0.0},{\"name\":\"Test Product F\",\"price\":999999999999.0,\"quantity\":0.0}]";
        private IExercise2Service _exercise2Service;

        [TestInitialize]
        public void Initialize()
        {
            //arrange
            var messageHandler = Substitute.ForPartsOf<MockHttpMessageHandler>(jsonResponse, HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler);

            _exercise2Service = Substitute.ForPartsOf<Exercise2Service>(httpClient);
        }

        [TestMethod]
        public async Task Exercise2Service_SortProduct_ReturnsProductResponse()
        {
            //act
            var response = await _exercise2Service.SortProducts("High");
            //assert
            Assert.AreEqual(5, response.Count());
        }

        [TestMethod]
        public async Task Exercise2Service_SortAsending_ReturnsProductResponse()
        {
            //act
            var response = await _exercise2Service.SortProducts("Ascending");
            var firstProduct = response.First();
            //assert
            Assert.AreEqual("Test Product A", firstProduct.Name);
        }

        [TestMethod]
        public async Task Exercise2Service_SortDescending_ReturnsProductResponse()
        {
            //act
            var response = await _exercise2Service.SortProducts("Descending");
            var firstProduct = response.First();
            //assert
            Assert.AreEqual("Test Product F", firstProduct.Name);
        }

        [TestMethod]
        public async Task Exercise2Service_SortLow_ReturnsProductResponse()
        {
            //arrange
            decimal price = 5.0M;
            //act
            var response = await _exercise2Service.SortProducts("Low");
            var firstProduct = response.First();
            //assert
            Assert.AreEqual(price, firstProduct.Price);
        }

        [TestMethod]
        public async Task Exercise2Service_SortHigh_ReturnsProductResponse()
        {
            //arrange
            decimal price = 999999999999.0M;
            //act
            var response = await _exercise2Service.SortProducts("High");
            var firstProduct = response.First();
            //assert
            Assert.AreEqual(price, firstProduct.Price);
        }
    }
}
