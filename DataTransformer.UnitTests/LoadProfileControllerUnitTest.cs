using System;
using DataTransformer.API.Controllers;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using DataTransformer.Data.Model;
using DataTransformer.Data.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using AutoFixture;
using NSubstitute;

namespace DataTransformer.UnitTests
{
    [TestClass]
    public class LoadProfileControllerUnitTest
    {
        private readonly Fixture _fixture;
        private readonly IGenericRepository<LoadProfileAggregated> _repo;
        private readonly LoadProfilesController _controller;

        public LoadProfileControllerUnitTest()
        {
            _fixture = new Fixture();
            _repo = Substitute.For<IGenericRepository<LoadProfileAggregated>>();
            _controller = new LoadProfilesController(_repo);
        }

        [Fact]
        public void GetAggregatedLoadProfileData_WhenCalled_ReturnsProperDataType()
        {
            //arrange 
            var dummyData = _fixture.Create<IEnumerable<LoadProfileAggregated>>();
            _repo.GetAggregatedData().Returns(dummyData);

            //act
            var response = _controller.GetAggregatedLoadProfileData();

            //assert
            Assert.IsInstanceOfType(response, typeof(IEnumerable<LoadProfileAggregated>));
        }

        [Fact]
        public void GetAggregatedLoadProfileData_WhenCalled_ReturnsAggregatedItems()
        {
            //arrange 
            _repo.GetAggregatedData().Returns(LoadProfileTestData.GetAggregatedTestData());

            //act
            var response = _controller.GetAggregatedLoadProfileData();

            // Assert
            response.Should().HaveCount(2);
        }

        [Fact]
        public void GetAggregatedLoadProfileData_WhenCalled_CheckMinValue()
        {
            //arrange 
            _repo.GetAggregatedData().Returns(LoadProfileTestData.GetAggregatedTestData());

            //act
            var response = _controller.GetAggregatedLoadProfileData();

            // Assert
            response.ToList()[1].Median.Should().Be(2);
        }

        [Fact]
        public void GetAggregatedLoadProfileData_WhenExceptionInDataAccess_ShouldPass()
        {
            //arrange 
            _repo.GetAggregatedData().Returns(_ => throw new InvalidOperationException());

            //act
            Action act = () => _controller.GetAggregatedLoadProfileData();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }
    }
}
