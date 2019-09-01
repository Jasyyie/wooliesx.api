using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using wooliesx.service.services;
using wooliesx.model.models;
using wooliesx.api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace wooliesx.test.controllers
{
    /// <summary>
    /// controller test Exercise 2
    /// </summary>
    [TestClass]
    public class Exercise2ControllerTests
    {
        private IExercise2Service _exercise2Service;
        private SortController _sortController;
        [TestInitialize]
        public void Initialize()
        {
            // arrange
            _exercise2Service = Substitute.For<IExercise2Service>();
            List<Product> product = new List<Product>();
            product.Add(new Product() { Name = "Jas", Price = 99, Quantity = 1 });
            _exercise2Service.SortProducts("High").Returns(product);
            _sortController = Substitute.ForPartsOf<SortController>(_exercise2Service);

        }

        [TestMethod]
        public async Task SortController_Get_ReturnsOk()
        {
            // act
            var controllerResponse = _sortController.Get("High");
            var okResult = await controllerResponse as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
