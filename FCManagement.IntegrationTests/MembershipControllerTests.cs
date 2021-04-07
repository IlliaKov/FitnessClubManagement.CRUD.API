using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FCManagement.Entities;
using FCManagement.IntegrationTests.Util;
using Newtonsoft.Json;
using Xunit;

namespace FCManagement.IntegrationTests
{
    public class MembershipControllerTests
    {
        private BaseTestFixture _fixture;

        public MembershipControllerTests()
        {
            _fixture = new BaseTestFixture();
        }

        [Fact]
        public async Task Get_ShouldReturnListResult()
        {
            // Act
            var response = await _fixture.Client.GetAsync("api/Membership");
            response.EnsureSuccessStatusCode();
            var models = JsonConvert.DeserializeObject<IEnumerable<Membership>>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotEmpty(models);
        }

        [Fact]
        public async Task Post_ShouldCreateNewObject()
        {
            //Arrange
            var fixture = new Fixture();
            var fakeObject = fixture
                .Build<Membership>()
                .With(x => x.Name, "test1")
                .Create();
            var fakeObjectJson = JsonConvert.SerializeObject(fakeObject);
            var httpContent = new StringContent(fakeObjectJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PostAsync("api/Membership", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.Memberships, answer => answer.Name == "test1");

        }

        [Fact]
        public async Task Put_ShouldUpdateExistingObject()
        {
            //Arrange
            var entity = _fixture.DbContext.Memberships.Last();
            entity.Name = "test2";
            var objectJson = JsonConvert.SerializeObject(entity);

            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PutAsync("api/Membership", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.Memberships, x => x.Name == "test2");
        }

        [Fact]
        public async Task Delete_ShouldDeleteExistingObject()
        {
            //Arrange
            var fixture = new Fixture();
            var entity = fixture.Create<Membership>();
            var objectJson = JsonConvert.SerializeObject(entity);
            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/Membership", httpContent);

            //Act
            var response = await _fixture.Client.DeleteAsync("api/Membership/" + entity.MembershipId);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.DoesNotContain(_fixture.DbContext.Memberships, x => x.MembershipId == entity.MembershipId);
        }

        [Fact]
        public async Task GetById_ShouldReturnExistingObject()
        {
            //Arrange
            var fixture = new Fixture();
            var entity = fixture.Create<Membership>();
            var objectJson = JsonConvert.SerializeObject(entity);
            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/Membership", httpContent);

            //Act
            var response = await _fixture.Client.GetAsync("api/Membership/" + entity.MembershipId);
            response.EnsureSuccessStatusCode();

            var responseObject = JsonConvert.DeserializeObject<Membership>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(entity.MembershipId, responseObject.MembershipId);
        }
    }
}