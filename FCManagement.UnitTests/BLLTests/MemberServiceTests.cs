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
    public class MemberServiceTests
    {
        private Mock<IMemberRepository> mockedRepository;
        private MemberService service;
        private Fixture fixture;

        //Setup
        public MemberServiceTests()
        {
            mockedRepository = new Mock<IMemberRepository>();
            service = new MemberService(mockedRepository.Object);
            fixture = new Fixture();
        }

        [Fact] //юніт-тест на виконання підрахунку сутності, перевірка на повертання кількості певної сутності.
        public async Task CountAllAsync_ReturnsCountOfAllInstuctors()
        {

            await service.CountAllAsync();

            mockedRepository.Verify(x => x.CountAllAsync());
        }

        [Fact] //юніт-тест на створення конкретної сутності, перевірка на створення сутності. 
        public async Task CreateAsync_EntityCreated()
        {
            var dto = fixture.Create<MemberDTO>();

            await service.CreateAsync(dto);

            mockedRepository.Verify(x => x.CreateAsync(It.IsAny<Member>()));
        }

        [Fact] //юніт-тест на видалення конкретної сутності, перевірка на видалення сутності.
        public async Task DeleteAsync_EntityDeleted()
        {
            var id = Guid.NewGuid();

            await service.DeleteAsync(id);

            mockedRepository.Verify(x => x.DeleteAsync(id));

        }

        [Fact] //юніт-тест на пошук за id сутності, перевірка на виклик пошуку id сутності. 
        public async Task GetByIdAsync_RepositoryInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Create<Member>();
            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.GetByIdAsync(id);

            mockedRepository.Verify(x => x.GetByIdAsync(id));
        }

        [Fact] //юніт-тест на пошук за id сутності, перевірка на повернення даних пошуку id сутності. 
        public async Task GetByIdAsync_DtoReturned()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Create<Member>();
            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            var result = await service.GetByIdAsync(id);

            Assert.Equal(entity.FullName, result.FullName);
            Assert.Equal(entity.Email, result.Email);
            Assert.Equal(entity.Gender, result.Gender);
            Assert.Equal(entity.HomeAddress, result.HomeAddress);
            Assert.Equal(entity.MemberId, result.MemberId);
            Assert.Equal(entity.PhoneNumber, result.PhoneNumber);
            Assert.Equal(entity.Age, result.Age);
        }

        [Fact] //юніт-тест на оновлення даних конкретної сутності, перевірка на виклик оновлення сутності. 
        public async Task UpdateAsync_RepositoryUpdateInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<Member>().With(x => x.MemberId, id).Create();
            var dto = fixture.Build<MemberDTO>().With(x => x.MemberId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.UpdateAsync(dto);

            mockedRepository.Verify(x => x.UpdateAsync(entity));
        }

        [Fact] //юніт-тест на оновлення даних конкретної сутності, перевірка на виклик пошуку даних сутності. 
        public async Task UpdateAsync_RepositoryGetByIdInvokes()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<Member>().With(x => x.MemberId, id).Create();
            var dto = fixture.Build<MemberDTO>().With(x => x.MemberId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            await service.UpdateAsync(dto);

            mockedRepository.Verify(x => x.GetByIdAsync(id));
        }

        [Fact] //юніт-тест на оновлення даних конкретної сутності, перевірка на повернення даних оновлення сутності. 
        public async Task UpdateAsync_ReturnsFalse()
        {
            var id = Guid.NewGuid();
            var entity = fixture.Build<Member>().With(x => x.MemberId, id).Create();
            var dto = fixture.Build<MemberDTO>().With(x => x.MemberId, id).Create();

            mockedRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(entity);

            var result = await service.UpdateAsync(dto);

            Assert.False(result);
        }

        [Fact] //юніт-тест на повернення усіх даних сутності, перевірка на повернення усіх даних сутності. 
        public async Task GetAllAsync_RepositoryInvokes()
        {
            await service.GetAllAsync();

            mockedRepository.Verify(x => x.GetAllAsync());
        }
    }
}
