using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;
using Fetch_N_Store.Models;
using Fetch_N_Store.DAL;

namespace Fetch_N_Store.Tests
{
    [TestClass]
    public class ResponseRepoTests
    {
        Mock<ResponseContext> mock_context { get; set; }
        Mock<DbSet<Response>> mock_response_table { get; set; }
        List<Response> response_list { get; set; }
        ResponseRepo repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = response_list.AsQueryable();

            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(c => c.Responses).Returns(mock_response_table.Object);

            mock_response_table.Setup(t => t.Add(It.IsAny<Response>())).Callback((Response r) => response_list.Add(r));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ResponseContext>();
            mock_response_table = new Mock<DbSet<Response>>();
            response_list = new List<Response>();
            repo = new ResponseRepo(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void ResponseRepoOriginallyHasNoResponses()
        {
            //Arrange
            List<Response> responses_returned = repo.GetAllResponses();
            //Act
            int expected_response_count = 0;
            int actual_response_count = responses_returned.Count();
            //Assert
            Assert.AreEqual(expected_response_count, actual_response_count);
        }

        [TestMethod]
        public void ResponseRepoCanAddStudent()
        {
            //Arrange
            repo.AddResponse(new Response { ResponseId = 1, StatusCode = 200, URL = "www.google.com", ResponseTime = new DateTime() });
            List<Response> responses_returned = repo.GetAllResponses();
            //Act
            int expected_response_count = 1;
            int actual_response_count = responses_returned.Count();
            //Assert
            Assert.AreEqual(expected_response_count, actual_response_count);
        }
    }
}
