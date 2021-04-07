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
    public class InstructorControllerTests
    {
        private BaseTestFixture _fixture;

        public InstructorControllerTests()
        {
            _fixture = new BaseTestFixture();
        }

        [Fact]
        public async Task Get_ShouldReturnListResult()
        {
            // Act
            var response = await _fixture.Client.GetAsync("api/Instructor");
            response.EnsureSuccessStatusCode();
            var models = JsonConvert.DeserializeObject<IEnumerable<Instructor>>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotEmpty(models);
        }

        [Fact]
        public async Task Post_ShouldCreateNewInstructor()
        {
            //Arrange
            var fixture = new Fixture();
            var fakeInstructor = fixture
                .Build<Instructor>()
                .With(x => x.FullName, "test1")
                .Create();
            var fakeInstructorJson = JsonConvert.SerializeObject(fakeInstructor);
            var httpContent = new StringContent(fakeInstructorJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PostAsync("api/Instructor", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.Instructors, answer => answer.FullName == "test1");

        }

        [Fact]
        public async Task Put_ShouldUpdateExistingInstructor()
        {
            //Arrange
            var instructor = _fixture.DbContext.Instructors.Last();
            instructor.FullName = "test2";
            var instructorJson = JsonConvert.SerializeObject(instructor);

            var httpContent = new StringContent(instructorJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _fixture.Client.PutAsync("api/Instructor", httpContent);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Contains(_fixture.DbContext.Instructors, x => x.FullName == "test2");
        }

        [Fact]
        public async Task Delete_ShouldDeleteExistingInstructor()
        {
            //Arrange
            var fixture = new Fixture();
            var instructor = fixture.Create<Instructor>();
            var instructorJson = JsonConvert.SerializeObject(instructor);
            var httpContent = new StringContent(instructorJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/Instructor", httpContent);

            //Act
            var response = await _fixture.Client.DeleteAsync("api/Instructor/" + instructor.InstructorId);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.DoesNotContain(_fixture.DbContext.Instructors, x => x.InstructorId == instructor.InstructorId);
        }

        [Fact]
        public async Task GetById_ShouldReturnExistingInstructor()
        {
            //Arrange
            var fixture = new Fixture();
            var instructor = fixture.Create<Instructor>();
            var instructorJson = JsonConvert.SerializeObject(instructor);
            var httpContent = new StringContent(instructorJson, System.Text.Encoding.UTF8, "application/json");

            await _fixture.Client.PostAsync("api/Instructor", httpContent);

            //Act
            var response = await _fixture.Client.GetAsync("api/Instructor/" + instructor.InstructorId);
            response.EnsureSuccessStatusCode();

            var responseObject = JsonConvert.DeserializeObject<Instructor>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(instructor.InstructorId, responseObject.InstructorId);
        }
    }
}