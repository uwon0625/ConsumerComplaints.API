using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsumerComplaints.API.Controllers;
using System.Linq;
using ConsumerComplaints.API.Models;
using Moq;
using System.Data.Entity;
using System.Web.Http.Results;

namespace ConsumerComplaints.Test.Controllers
{
    [TestClass]
    public class ComplaintControllerTest
    {
        Mock<IComplaintContext> mock;
        ComplaintsController controller;
        Mock<IDbSet<ConsumerComplaint>> dbSetMock;

        ConsumerComplaint complaintToAdd = new ConsumerComplaint { Id = 14, DateReceived = DateTime.Parse("1/1/2012"), Company = "ABC", Product = "Loan", ZIP = "93551" };
        IEnumerable<ConsumerComplaint> complaints = new List<ConsumerComplaint> {
                new ConsumerComplaint { Id = 3, DateReceived =DateTime.Parse("1/1/2012"), Company="ABC", Product="Loan", ZIP= "93551"},
                new ConsumerComplaint { Id = 6, DateReceived =DateTime.Parse("1/21/2012"), Company="ABC", Product="Loan", ZIP= "93551"},
                new ConsumerComplaint { Id = 9, DateReceived =DateTime.Parse("12/1/2012"), Company="DEF", Product="Loan", ZIP= "93551"},
                new ConsumerComplaint { Id = 8, DateReceived =DateTime.Parse("1/1/2012"), Company="DEF", Product="Loan2", ZIP= "33055"},
                new ConsumerComplaint { Id = 123, DateReceived =DateTime.Parse("11/11/2012"), Company="GHI", Product="Loan3", ZIP= "44222"}
            };
        // Convert the IEnumerable list to an IQueryable list
        IQueryable<ConsumerComplaint> queryableList;

        [TestInitialize]
        public void Initialize()
        {
            queryableList = complaints.AsQueryable();
            dbSetMock = new Mock<IDbSet<ConsumerComplaint>>();
            dbSetMock.Setup(m => m.Provider).Returns(queryableList.Provider);
            dbSetMock.Setup(m => m.Expression).Returns(queryableList.Expression);
            dbSetMock.Setup(m => m.ElementType).Returns(queryableList.ElementType);
            dbSetMock.Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());

            mock = new Mock<IComplaintContext>();
            mock.Setup(c => c.ConsumerComplaints).Returns(dbSetMock.Object);
            controller = new ComplaintsController(mock.Object);           
        }

        [TestMethod]
        public void GetConsumerComplaints_ShouldReturnComplaints()
        {
            //arrange

            //act            
            var result = controller.GetConsumerComplaints();
            
            var data = result as OkNegotiatedContentResult<List<ConsumerComplaint>>;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, data.Content.Count());
        }
        [TestMethod]
        public void GetConsumerComplaint_ShouldReturnComplaintWithValidId()
        {
            //arrange

            //act
            var result = controller.GetConsumerComplaint(6) as OkNegotiatedContentResult<ConsumerComplaint>;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Content.Id);
        }

        [TestMethod]
        public void GetConsumerComplaint_ShouldReturnNoDataWithInalidId()
        {
            //arrange

            //act
            var result = controller.GetConsumerComplaint(-1) as OkNegotiatedContentResult<ConsumerComplaint>;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void PostConsumerComplaint_ShouldAddComplaintWithValidData()
        {
            //arrange

            //act
            controller.PostConsumerComplaint(complaintToAdd).Wait();

            //assert
            // Exception will be thrown if failed
        }
    }
}
