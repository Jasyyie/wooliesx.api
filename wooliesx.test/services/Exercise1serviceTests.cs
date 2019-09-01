using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using wooliesx.service.services;
using wooliesx.model.models;


namespace wooliesx.test.services
{
    [TestClass]
    public class Exercise1ServiceTests
    {
        /// <summary>
        /// service test Exercise 1
        /// </summary>
        private IExercise1Service _exercise1Service;
        [TestInitialize]
        public void Initialize()
        {
            //arrange
            _exercise1Service = Substitute.ForPartsOf<Exercise1Service>();
        }

        [TestMethod]
        public void Exercise1Service_GetUser_ReturnsUserResponse()
        {
            //act
            var response = _exercise1Service.GetUser();
            //assert
            Assert.AreEqual("Jasmine Kaur", response.Name);
        }
    }
}
