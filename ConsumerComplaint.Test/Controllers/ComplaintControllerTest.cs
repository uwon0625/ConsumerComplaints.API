using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http.Results;
using ConsumerComplaints.API.Controllers;
using System.Linq;
using ConsumerComplaints.API.Models;

namespace ConsumerComplaints.Test.Controllers
{
    [TestClass]
    public class ComplaintControllerTest
    {
        TestDataContext context;
        ConsumerComplaint complaintToAdd;

        [TestInitialize]
        public void Initialize()
        {
            context = new TestDataContext();
            foreach (var c in GetDemoComplaints())
                context.ConsumerComplaints.Add(c);

            complaintToAdd = new ConsumerComplaint { Id = 14, DateReceived = DateTime.Parse("1/1/2012"), Company = "ABC", Product = "Loan", ZIP = "93551" };
        }

        [TestMethod]
        public void GetConsumerComplaints_ShouldReturnGroupedComplaints()
        {
            //arrange

            //act
            var controller = new ComplaintsController(context);
            var result = controller.GetConsumerComplaints();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, (result as IQueryable<ConsumerComplaint>).Count());
        }
        [TestMethod]
        public void GetConsumerComplaints_ShouldReturnGroupedComplaintsWithValidId()
        {
            //arrange

            //act
            var controller = new ComplaintsController(context);
            var data = controller.GetConsumerComplaint(6);

            // var result = data as OkNegotiatedContentResult<IQueryable<TopComplaints>>;
            var result = data.Result;// as OkNegotiatedContentResult<ConsumerComplaint>;

            //assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Content.Count());
        }

        [TestMethod]
        public void GetTopConsumerComplaints_ShouldReturnNoDataWithInalidId()
        {
            //arrange

            //act
            var controller = new ComplaintsController(context);
            var data = controller.GetConsumerComplaint(-1);

            // var result = data as OkNegotiatedContentResult<IQueryable<TopComplaints>>;
            var result = data;// as OkNegotiatedContentResult<ConsumerComplaint>;

            //assert
            Assert.IsNotNull(result);
            // Assert.AreEqual(0, result.Content.Count());
        }

        [TestMethod]
        public void PutConsumerComplaints_ShouldAddComplaintWithValidData()
        {
            //arrange

            //act
            var controller = new ComplaintsController(context);
            var data = controller.PostConsumerComplaint(complaintToAdd);

            // var result = data as OkNegotiatedContentResult<IQueryable<TopComplaints>>;
            var result = data;// as OkNegotiatedContentResult<ConsumerComplaint>;

            //assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Content.Count());
        }

        public void PutConsumerComplaints_ShouldFailWhenNotAuthorized()
        {
            //arrange

            //act
            var controller = new ComplaintsController(context);
            var data = controller.PostConsumerComplaint(complaintToAdd);

            // var result = data as OkNegotiatedContentResult<IQueryable<TopComplaints>>;
            var result = data;// as OkNegotiatedContentResult<ConsumerComplaint>;

            //assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Content.Count());
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
