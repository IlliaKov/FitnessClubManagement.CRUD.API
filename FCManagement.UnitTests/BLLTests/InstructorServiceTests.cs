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
    public class InstructorServiceTests
    {
        private Mock<IInstructorRepository> mockedRepository;
        private InstructorService service;
        private Fixture fixture;
        public InstructorServiceTests()
        {
            mockedRepository = new Mock<IInstructorRepository>();
            service = new InstructorService(mockedRepository.Object);
            fixture = new Fixture();
        }

        [Fact]
        public async Task CountAllAsync_ReturnsCountOfAllInstuctors()
        {

            await service.CountAllAsync();

            mockedRepository.Verify(x=>x.CountAllAsync());
        }

        [Fact]
        public async Task CreateAsync_EntityCreated()
        {
            var dto = fixture.Create<InstructorDTO>();

            await service.CreateAsync(dto);

            mockedRepository.Verify(x=>x.CreateAsync(It.IsAny<Instructor>()));
        }

        [Fact]
        public async Task DeleteAsync_EntityDeleted()
        {
            var id = Guid.NewGuid();

            await service.DeleteAsync(id);

            mockedRepository.Verify(x=>x.DeleteAsync(id));

        }

        [Fact]
        public async Task GetByIdAsync_RepositoryInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Create<Instructor>();
            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.GetByIdAsync(id);

            mockedRepository.Verify(x=>x.GetByIdAsync(id));
        }

        [Fact]
        public async Task GetByIdAsync_DtoReturned()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Create<Instructor>();
            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            var result = await service.GetByIdAsync(id);

            Assert.Equal(entity.FullName, result.FullName);
            Assert.Equal(entity.Email, result.Email);
            Assert.Equal(entity.Gender, result.Gender);
            Assert.Equal(entity.HomeAddress, result.HomeAddress);
            Assert.Equal(entity.InstructorId, result.InstructorId);
            Assert.Equal(entity.PhoneNumber, result.PhoneNumber);
        }

        [Fact]
        public async Task UpdateAsync_RepositoryUpdateInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<Instructor>().With(x=>x.InstructorId, id).Create();
            var dto = fixture.Build<InstructorDTO>().With(x => x.InstructorId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.UpdateAsync(dto);

            mockedRepository.Verify(x=>x.UpdateAsync(entity));
        }

        [Fact]
        public async Task UpdateAsync_RepositoryGetByIdInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<Instructor>().With(x => x.InstructorId, id).Create();
            var dto = fixture.Build<InstructorDTO>().With(x => x.InstructorId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.UpdateAsync(dto);

            mockedRepository.Verify(x => x.GetByIdAsync(id));
        }

        [Fact]
        public async Task UpdateAsync_ReturnsFalse()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<Instructor>().With(x => x.InstructorId, id).Create();
            var dto = fixture.Build<InstructorDTO>().With(x => x.InstructorId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            var result = await service.UpdateAsync(dto);

            Assert.False(result);
        }

        [Fact]
        public async Task GetAllAsync_RepositoryInvokes()
        {
            await service.GetAllAsync();

            mockedRepository.Verify(x=>x.GetAllAsync());
        }
    }
}