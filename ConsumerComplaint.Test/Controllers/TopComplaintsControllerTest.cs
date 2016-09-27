using System;
using ConsumerComplaints.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsumerComplaints.API.Controllers;
using System.Linq;
using System.Web.Http.Results;

namespace ConsumerComplaints.Test.Controllers
{
    [TestClass]
    public class TopComplaintsControllerTest
    {
        TestDataContext context;
        TopComplaintsController controller;

        [TestInitialize]
        public void Initialize()
        {
            context = new TestDataContext();
            foreach (var c in GetDemoComplaints())
                context.ConsumerComplaints.Add(c);
            controller = new TopComplaintsController(context);
        }

        [TestMethod]
        public void GetTopConsumerComplaints_ShouldReturnGroupedComplaints()
        {
            //arrange

            //act
            var result = controller.GetTopConsumerComplaints();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, (result as IQueryable<TopComplaints>).Count());
        }
        [TestMethod]
        public void GetTopConsumerComplaints_ShouldReturnGroupedComplaintsWithValidZip()
        {
            //arrange

            //act
            var data = controller.GetTopConsumerComplaints("93551");

            var result = data as OkNegotiatedContentResult<List<TopComplaints>>;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Content.Count());
        }

        [TestMethod]
        public void GetTopConsumerComplaints_ShouldReturnNoDataWithInalidZip()
        {
            //arrange

            //act
            var data = controller.GetTopConsumerComplaints("-1");

            var result = data as OkNegotiatedContentResult<List<TopComplaints>>;

            //assert
            Assert.AreEqual(0, result.Content.Count());
        }

        private List<ConsumerComplaint> GetDemoComplaints()
        {
            return new List<ConsumerComplaint> {
                new ConsumerComplaint { Id = 3, DateReceived =DateTime.Parse("1/1/2012"), Company="ABC", Product="Loan", ZIP= "93551"},
                new ConsumerComplaint { Id = 6, DateReceived =DateTime.Parse("1/21/2012"), Company="ABC", Product="Loan", ZIP= "93551"},
                new ConsumerComplaint { Id = 9, DateReceived =DateTime.Parse("12/1/2012"), Company="DEF", Product="Loan", ZIP= "93551"},
                new ConsumerComplaint { Id = 8, DateReceived =DateTime.Parse("1/1/2012"), Company="DEF", Product="Loan2", ZIP= "33055"},
                new ConsumerComplaint { Id = 123, DateReceived =DateTime.Parse("11/11/2012"), Company="GHI", Product="Loan3", ZIP= "44222"}
            };
        }
    }
}
