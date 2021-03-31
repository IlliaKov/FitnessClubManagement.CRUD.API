using System;
using System.Threading.Tasks;
using AutoFixture;
using FCManagement.BL.IMPL;
using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using FCManagement.Models;
using Moq;
using Xunit;

namespace FCManagement.UnitTests.BLLTests
{
    public class WorkoutPlanServiceTests
    {
        private Mock<IWorkoutPlanRepository> mockedRepository;
        private WorkoutPlanService service;
        private Fixture fixture;
        public WorkoutPlanServiceTests()
        {
            mockedRepository = new Mock<IWorkoutPlanRepository>();
            service = new WorkoutPlanService(mockedRepository.Object);
            fixture = new Fixture();
        }

        [Fact]
        public async Task CountAllAsync_ReturnsCountOfAllInstuctors()
        {

            await service.CountAllAsync();

            mockedRepository.Verify(x => x.CountAllAsync());
        }

        [Fact]
        public async Task CreateAsync_EntityCreated()
        {
            var dto = fixture.Create<WorkoutPlanDTO>();

            await service.CreateAsync(dto);

            mockedRepository.Verify(x => x.CreateAsync(It.IsAny<WorkoutPlan>()));
        }

        [Fact]
        public async Task DeleteAsync_EntityDeleted()
        {
            var id = Guid.NewGuid();

            await service.DeleteAsync(id);

            mockedRepository.Verify(x => x.DeleteAsync(id));

        }

        [Fact]
        public async Task GetByIdAsync_RepositoryInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Create<WorkoutPlan>();
            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.GetByIdAsync(id);

            mockedRepository.Verify(x => x.GetByIdAsync(id));
        }

        [Fact]
        public async Task GetByIdAsync_DtoReturned()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Create<WorkoutPlan>();
            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            var result = await service.GetByIdAsync(id);

            Assert.Equal(entity.WorkoutDate, result.WorkoutDate);
            Assert.Equal(entity.WorkoutTime, result.WorkoutTime);
            Assert.Equal(entity.WorkoutPlanId, result.WorkoutPlanId);
        }

        [Fact]
        public async Task UpdateAsync_RepositoryUpdateInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<WorkoutPlan>().With(x => x.WorkoutPlanId, id).Create();
            var dto = fixture.Build<WorkoutPlanDTO>().With(x => x.WorkoutPlanId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.UpdateAsync(dto);

            mockedRepository.Verify(x => x.UpdateAsync(entity));
        }

        [Fact]
        public async Task UpdateAsync_RepositoryGetByIdInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<WorkoutPlan>().With(x => x.WorkoutPlanId, id).Create();
            var dto = fixture.Build<WorkoutPlanDTO>().With(x => x.WorkoutPlanId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.UpdateAsync(dto);

            mockedRepository.Verify(x => x.GetByIdAsync(id));
        }

        [Fact]
        public async Task UpdateAsync_ReturnsFalse()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<WorkoutPlan>().With(x => x.WorkoutPlanId, id).Create();
            var dto = fixture.Build<WorkoutPlanDTO>().With(x => x.WorkoutPlanId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            var result = await service.UpdateAsync(dto);

            Assert.False(result);
        }

        [Fact]
        public async Task GetAllAsync_RepositoryInvokes()
        {
            await service.GetAllAsync();

            mockedRepository.Verify(x => x.GetAllAsync());
        }
    }
}
