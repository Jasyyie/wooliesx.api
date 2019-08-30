using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using wooliesx.service.services;
using wooliesx.model.models;
using wooliesx.api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace wooliesx.test.controllers
{
    [TestClass]
    public class Exercise1ControllerTests
    {
        private IExercise1service _exercise1Service;
        private UserController _userController;
        [TestInitialize]
        public void Initialize()
        {
            // arrange
            _exercise1Service = Substitute.For<Exercise1service>();
            //_exercise1Service.GetUser().Returns(new UserResponse() { Name = "Jas", Token = "123" });
            _userController = Substitute.ForPartsOf<UserController>(_exercise1Service);

        }

        [TestMethod]
        public void UserController_Get_ReturnsOk()
        {
            // act
            var controllerResponse = _userController.Get();
            var okResult = controllerResponse as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
