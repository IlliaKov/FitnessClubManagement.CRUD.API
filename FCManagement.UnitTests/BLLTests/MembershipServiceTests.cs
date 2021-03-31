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
    public class MembershipServiceTests
    {
        private Mock<IMembershipRepository> mockedRepository;
        private MembershipService service;
        private Fixture fixture;
        public MembershipServiceTests()
        {
            mockedRepository = new Mock<IMembershipRepository>();
            service = new MembershipService(mockedRepository.Object);
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
            var dto = fixture.Create<MembershipDTO>();

            await service.CreateAsync(dto);

            mockedRepository.Verify(x => x.CreateAsync(It.IsAny<Membership>()));
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
            var entity = fixture.Create<Membership>();
            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.GetByIdAsync(id);

            mockedRepository.Verify(x => x.GetByIdAsync(id));
        }

        [Fact]
        public async Task GetByIdAsync_DtoReturned()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Create<Membership>();
            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            var result = await service.GetByIdAsync(id);

            Assert.Equal(entity.Name, result.Name);
            Assert.Equal(entity.Cost, result.Cost);
            Assert.Equal(entity.MembershipPeriod, result.MembershipPeriod);
            Assert.Equal(entity.MembershipId, result.MembershipId);
        }

        [Fact]
        public async Task UpdateAsync_RepositoryUpdateInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<Membership>().With(x => x.MembershipId, id).Create();
            var dto = fixture.Build<MembershipDTO>().With(x => x.MembershipId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.UpdateAsync(dto);

            mockedRepository.Verify(x => x.UpdateAsync(entity));
        }

        [Fact]
        public async Task UpdateAsync_RepositoryGetByIdInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<Membership>().With(x => x.MembershipId, id).Create();
            var dto = fixture.Build<MembershipDTO>().With(x => x.MembershipId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.UpdateAsync(dto);

            mockedRepository.Verify(x => x.GetByIdAsync(id));
        }

        [Fact]
        public async Task UpdateAsync_ReturnsFalse()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<Membership>().With(x => x.MembershipId, id).Create();
            var dto = fixture.Build<MembershipDTO>().With(x => x.MembershipId, id).Create();

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
