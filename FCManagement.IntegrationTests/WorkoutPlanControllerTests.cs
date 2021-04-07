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
    public class WorkoutPlanControllerTests
    {
        private BaseTestFixture _fixture;

        public WorkoutPlanControllerTests()
        {
            _fixture = new BaseTestFixture();
        }

        [Fact]
        public async Task Get_ShouldReturnListResult()
        {
            // Act
            var response = await _fixture.Client.GetAsync("api/WorkoutPlan");
            response.EnsureSuccessStatusCode();
            var models = JsonConvert.DeserializeObject<IEnumerable<WorkoutPlan>>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotEmpty(models);
        }

        [Fact]
        public async Task Post_ShouldCreateNewObject()
        {
            //Arrange
            var fixture = new Fixture();
            var fakeObject = fixture
                .Build<WorkoutPlan>()
                .With(x => x.WorkoutTime, 3)
                .Create();
            var fakeObjectJson = JsonConvert.SerializeObject(fakeObject);
            var httpContent = new StringContent(fakeObjectJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PostAsync("api/WorkoutPlan", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.WorkoutPlans, answer => answer.WorkoutTime == 3);

        }

        [Fact]
        public async Task Put_ShouldUpdateExistingObject()
        {
            //Arrange
            var entity = _fixture.DbContext.WorkoutPlans.Last();
            entity.WorkoutTime = 3;
            var objectJson = JsonConvert.SerializeObject(entity);

            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PutAsync("api/WorkoutPlan", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.WorkoutPlans, x => x.WorkoutTime == 3);
        }

        [Fact]
        public async Task Delete_ShouldDeleteExistingObject()
        {
            //Arrange
            var fixture = new Fixture();
            var entity = fixture.Create<WorkoutPlan>();
            var objectJson = JsonConvert.SerializeObject(entity);
            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/WorkoutPlan", httpContent);

            //Act
            var response = await _fixture.Client.DeleteAsync("api/WorkoutPlan/" + entity.WorkoutPlanId);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.DoesNotContain(_fixture.DbContext.WorkoutPlans, x => x.WorkoutPlanId == entity.WorkoutPlanId);
        }

        [Fact]
        public async Task GetById_ShouldReturnExistingObject()
        {
            //Arrange
            var fixture = new Fixture();
            var entity = fixture.Create<WorkoutPlan>();
            var objectJson = JsonConvert.SerializeObject(entity);
            var httpContent = new StringContent(objectJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/WorkoutPlan", httpContent);

            //Act
            var response = await _fixture.Client.GetAsync("api/WorkoutPlan/" + entity.WorkoutPlanId);
            response.EnsureSuccessStatusCode();

            var responseObject = JsonConvert.DeserializeObject<WorkoutPlan>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(entity.WorkoutPlanId, responseObject.WorkoutPlanId);
        }
    }
}