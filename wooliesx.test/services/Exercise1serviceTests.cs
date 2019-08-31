using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using wooliesx.service.services;
using wooliesx.model.models;


namespace wooliesx.test.services
{
    [TestClass]
    public class Exercise1ServiceTests
    {
        private IExercise1Service _exercise1Service;
        [TestInitialize]
        public void Initialize()
        {
            _exercise1Service = Substitute.ForPartsOf<Exercise1Service>();
        }

        [TestMethod]
        public void Exercise1Service_GetUser_ReturnsUserResponse()
        {
            var response = _exercise1Service.GetUser();

            Assert.AreEqual("Jasmine Kaur", response.Name);
        }
    }
}
