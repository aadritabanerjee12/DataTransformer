using DataTransformer.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Assert = Xunit.Assert;
using System.Collections.Generic;
using DataTransformer.Data.Model;

namespace DataTransformer.UnitTests
{
    [TestClass]
    public class LoadProfileControllerUnitTest
    {
        [Fact]
        public void GetAggregatedLoadProfileData_WhenCalled_ReturnsActionResult()
        {
            //arrange 
            var mockRepo = new LoadProfileRepositoryMocker();
            var controller = new LoadProfilesController(mockRepo);

            //act
            var response = controller.GetAggregatedLoadProfileData();

            //assert
            Assert.IsType<List<LoadProfileAggregated>>(response);

        }

        [Fact]
        public void GetAggregatedLoadProfileData_WhenCalled_ReturnsAggregatedItems()
        {
            //arrange 
            var mockRepo = new LoadProfileRepositoryMocker();
            var controller = new LoadProfilesController(mockRepo);

            //act
            var response = controller.GetAggregatedLoadProfileData();

            // Assert
            var items = Assert.IsType<List<LoadProfileAggregated>>(response);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetAggregatedLoadProfileData_WhenCalled_CheckMinValue()
        {
            //arrange 
            var mockRepo = new LoadProfileRepositoryMocker();
            var controller = new LoadProfilesController(mockRepo);

            //act
            var response = controller.GetAggregatedLoadProfileData();

            // Assert
            var items = Assert.IsType<List<LoadProfileAggregated>>(response);
            Assert.Equal(2, items[1].Median);
        }

    }
}
