using FCManagement.BL.ABSTRACT;
using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using FCManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCManagement.BL.IMPL
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Task<int> CountAllAsync()
        {
            throw new NotImplementedException();
        }
        //public void AddObject(MemberDTO member)
        //{
        //    Member dbEntity = new Member()
        //    {
        //        FullName = member.FullName,
        //        Gender = member.Gender,
        //        Age = member.Age,
        //        Birthday = member.Birthday,
        //        Email = member.Email,
        //        HomeAddress = member.HomeAddress,
        //        PhoneNumber = member.PhoneNumber,
        //        JoiningDate = member.JoiningDate,
        //        EndOfMembership = member.EndOfMembership
        //    };
        //    _memberRepository.Add(dbEntity);
        //    _memberRepository.Save();
        //}
        public async Task CreateAsync(MemberDTO entity)
        {
            Member dbEntity = new Member()
            {
                FullName = entity.FullName,
                Gender = entity.Gender,
                Age = entity.Age,
                Birthday = entity.Birthday,
                Email = entity.Email,
                HomeAddress = entity.HomeAddress,
                PhoneNumber = entity.PhoneNumber,
                JoiningDate = entity.JoiningDate,
                EndOfMembership = entity.EndOfMembership
            };

            await _memberRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _memberRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MemberDTO>> GetAllAsync()
        { 
            return await _memberRepository.GetAllAsync(). Select   
                (m => new MemberDTO()
            {
                MemberId = m.MemberId,
                FullName = m.FullName,
                Gender = m.Gender,
                Age = m.Age,
                Birthday = m.Birthday,
                Email = m.Email,
                HomeAddress = m.HomeAddress,
                PhoneNumber = m.PhoneNumber,
                JoiningDate = m.JoiningDate,
                EndOfMembership = m.EndOfMembership
            });
        }

        public Task<MemberDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(MemberDTO entity)
        {
            throw new NotImplementedException();
        }

        //public void AddObject(MemberDTO member)
        //{
        //    Member dbEntity = new Member()
        //    {
        //        FullName = member.FullName,
        //        Gender = member.Gender,
        //        Age = member.Age,
        //        Birthday = member.Birthday,
        //        Email = member.Email,
        //        HomeAddress = member.HomeAddress,
        //        PhoneNumber = member.PhoneNumber,
        //        JoiningDate = member.JoiningDate,
        //        EndOfMembership = member.EndOfMembership
        //    };

        //    _memberRepository.Add(dbEntity);
        //    _memberRepository.Save();
        //}

        //public void DeleteObject(int id)
        //{
        //    _memberRepository.Delete(id);
        //}

        //public IEnumerable<MemberDTO> GetAll()
        //{
        //    return _memberRepository.GetAll().Select(m => new MemberDTO()
        //    {
        //        MemberId = m.MemberId,
        //        FullName = m.FullName,
        //        Gender = m.Gender,
        //        Age = m.Age,
        //        Birthday = m.Birthday,
        //        Email = m.Email,
        //        HomeAddress = m.HomeAddress,
        //        PhoneNumber = m.PhoneNumber,
        //        JoiningDate = m.JoiningDate,
        //        EndOfMembership = m.EndOfMembership
        //    });
        //}

        //public MemberDTO GetElementById(int id)
        //{
        //    Member fromDb = _memberRepository.GetById(id);

        //    MemberDTO memberDTO = new MemberDTO()
        //    {
        //        MemberId = fromDb.MemberId,
        //        FullName = fromDb.FullName,
        //        Gender = fromDb.Gender,
        //        Age = fromDb.Age,
        //        Birthday = fromDb.Birthday,
        //        Email = fromDb.Email,
        //        HomeAddress = fromDb.HomeAddress,
        //        PhoneNumber = fromDb.PhoneNumber,
        //        JoiningDate = fromDb.JoiningDate,
        //        EndOfMembership = fromDb.EndOfMembership
        //    };
        //    return memberDTO;
        //}

        //public void UpdateObject(MemberDTO member)
        //{
        //    Member memberBase = new Member()
        //    {
        //        MemberId = member.MemberId,
        //        FullName = member.FullName,
        //        Gender = member.Gender,
        //        Age = member.Age,
        //        Birthday = member.Birthday,
        //        Email = member.Email,
        //        HomeAddress = member.HomeAddress,
        //        PhoneNumber = member.PhoneNumber,
        //        JoiningDate = member.JoiningDate,
        //        EndOfMembership = member.EndOfMembership
        //    };
        //    _memberRepository.Update(memberBase);
        //}
    }
}
