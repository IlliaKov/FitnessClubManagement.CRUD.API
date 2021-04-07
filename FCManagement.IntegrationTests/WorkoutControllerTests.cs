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
    public class WorkoutControllerTests
    {
        private BaseTestFixture _fixture;

        public WorkoutControllerTests()
        {
            _fixture = new BaseTestFixture();
        }

        [Fact]
        public async Task Get_ShouldReturnListResult()
        {
            // Act
            var response = await _fixture.Client.GetAsync("api/Workout");
            response.EnsureSuccessStatusCode();
            var models = JsonConvert.DeserializeObject<IEnumerable<Workout>>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotEmpty(models);
        }

        [Fact]
        public async Task Post_ShouldCreateNewObject()
        {
            //Arrange
            var fixture = new Fixture();
            var fakeObject = fixture
                .Build<Workout>()
                .With(x => x.Name, "test1")
                .Create();
            var fakeObjectJson = JsonConvert.SerializeObject(fakeObject);
            var httpContent = new StringContent(fakeObjectJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PostAsync("api/Workout", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.Workouts, answer => answer.Name == "test1");

        }

        [Fact]
        public async Task Put_ShouldUpdateExistingObject()
        {
            //Arrange
            var entity = _fixture.DbContext.Workouts.Last();
            entity.Name = "test2";
            var objectJson = JsonConvert.SerializeObject(entity);

            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PutAsync("api/Workout", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.Workouts, x => x.Name == "test2");
        }

        [Fact]
        public async Task Delete_ShouldDeleteExistingObject()
        {
            //Arrange
            var fixture = new Fixture();
            var entity = fixture.Create<Workout>();
            var objectJson = JsonConvert.SerializeObject(entity);
            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/Workout", httpContent);

            //Act
            var response = await _fixture.Client.DeleteAsync("api/Workout/" + entity.WorkoutId);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.DoesNotContain(_fixture.DbContext.Workouts, x => x.WorkoutId == entity.WorkoutId);
        }

        [Fact]
        public async Task GetById_ShouldReturnExistingObject()
        {
            //Arrange
            var fixture = new Fixture();
            var entity = fixture.Create<Workout>();
            var objectJson = JsonConvert.SerializeObject(entity);
            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/Workout", httpContent);

            //Act
            var response = await _fixture.Client.GetAsync("api/Workout/" + entity.WorkoutId);
            response.EnsureSuccessStatusCode();

            var responseObject = JsonConvert.DeserializeObject<Workout>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(entity.WorkoutId, responseObject.WorkoutId);
        }
    }
}