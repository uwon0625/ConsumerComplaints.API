using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsumerComplaints.API.Models;
using ConsumerComplaints.API.Controllers;
using ConsumerComplaints.API;
using System.Web.Http.Results;

namespace ConsumerComplaints.Test.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        UserModel userModel = new UserModel { UserName = "test1", Password = "password1", ConfirmPassword = "password1" };
        AccountController controller;

        [TestInitialize]
        public void Initialize()
        {
            controller = new AccountController(new AuthRepository());
        }

        [TestCleanup]
        public void Cleanup()
        {
            controller.RemoveUser(userModel.UserName, userModel.Password);
        }

        [TestMethod]
        public void AccountController_ShouldRegisterValidUser()
        {
            //arrange

            //act
            var result = controller.Register(userModel).Result;

            //assert
            Assert.IsTrue(result is OkResult);
        }

        [TestMethod]
        public void AccountController_ShouldFailWithRegisteredUser()
        {
            //arrange

            //act
            var result = controller.Register(userModel).Result;
            var result2 = controller.Register(userModel).Result;

            //assert
            Assert.IsTrue(result is OkResult);
            Assert.IsFalse(result2 is OkResult);
        }

    }
}
