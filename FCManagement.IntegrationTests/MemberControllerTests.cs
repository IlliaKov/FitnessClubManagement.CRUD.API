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
    public class MemberControllerTests
    {
        private BaseTestFixture _fixture;

        public MemberControllerTests()
        {
            _fixture = new BaseTestFixture();
        }

        [Fact]
        public async Task Get_ShouldReturnListResult()
        {
            // Act
            var response = await _fixture.Client.GetAsync("api/Member");
            response.EnsureSuccessStatusCode();
            var models = JsonConvert.DeserializeObject<IEnumerable<Member>>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotEmpty(models);
        }

        [Fact]
        public async Task Post_ShouldCreateNewObject()
        {
            //Arrange
            var fixture = new Fixture();
            var fakeObject = fixture
                .Build<Member>()
                .With(x => x.FullName, "test1")
                .Create();
            var fakeObjectJson = JsonConvert.SerializeObject(fakeObject);
            var httpContent = new StringContent(fakeObjectJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PostAsync("api/Member", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.Members, answer => answer.FullName == "test1");

        }

        [Fact]
        public async Task Put_ShouldUpdateExistingObject()
        {
            //Arrange
            var entity = _fixture.DbContext.Members.Last();
            entity.FullName = "test2";
            var objectJson = JsonConvert.SerializeObject(entity);

            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PutAsync("api/Member", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.Members, x => x.FullName == "test2");
        }

        [Fact]
        public async Task Delete_ShouldDeleteExistingObject()
        {
            //Arrange
            var fixture = new Fixture();
            var entity = fixture.Create<Member>();
            var objectJson = JsonConvert.SerializeObject(entity);
            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/Member", httpContent);

            //Act
            var response = await _fixture.Client.DeleteAsync("api/Member/" + entity.MemberId);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.DoesNotContain(_fixture.DbContext.Members, x => x.MemberId == entity.MemberId);
        }

        [Fact]
        public async Task GetById_ShouldReturnExistingObject()
        {
            //Arrange
            var fixture = new Fixture();
            var entity = fixture.Create<Member>();
            var objectJson = JsonConvert.SerializeObject(entity);
            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/Member", httpContent);

            //Act
            var response = await _fixture.Client.GetAsync("api/Member/" + entity.MemberId);
            response.EnsureSuccessStatusCode();

            var responseObject = JsonConvert.DeserializeObject<Member>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(entity.MemberId, responseObject.MemberId);
        }
    }
}