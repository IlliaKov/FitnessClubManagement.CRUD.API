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

        public async Task<int> CountAllAsync()
        {
            return await _memberRepository.CountAllAsync();
        }
        
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
            return (await _memberRepository.GetAllAsync()).Select   
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

        public async Task<MemberDTO> GetByIdAsync(Guid id)
        {
            Member fromDb = await _memberRepository.GetByIdAsync(id);

            MemberDTO memberDTO = new MemberDTO()
            {
                MemberId = fromDb.MemberId,
                FullName = fromDb.FullName,
                Gender = fromDb.Gender,
                Age = fromDb.Age,
                Birthday = fromDb.Birthday,
                Email = fromDb.Email,
                HomeAddress = fromDb.HomeAddress,
                PhoneNumber = fromDb.PhoneNumber,
                JoiningDate = fromDb.JoiningDate,
                EndOfMembership = fromDb.EndOfMembership
            };
            return memberDTO;
        }

        public async Task<bool> UpdateAsync(MemberDTO entity)
        {
            var member = await _memberRepository.GetByIdAsync(entity.MemberId);

            member.MemberId = entity.MemberId;
            member.FullName = entity.FullName;
            member.Gender = entity.Gender;
            member.Age = entity.Age;
            member.Birthday = entity.Birthday;
            member.Email = entity.Email;
            member.HomeAddress = entity.HomeAddress;
            member.PhoneNumber = entity.PhoneNumber;
            member.JoiningDate = entity.JoiningDate;
            member.EndOfMembership = entity.EndOfMembership;
            
            return await _memberRepository.UpdateAsync(member);
        }
    }
}
