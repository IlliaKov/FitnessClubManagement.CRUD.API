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
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipService(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<int> CountAllAsync()
        {
            return await _membershipRepository.CountAllAsync();
        }

        public async Task CreateAsync(MembershipDTO entity)
        {
            Membership dbEntity = new Membership()
            {
                MembershipId = entity.MembershipId,
                Name = entity.Name,
                Cost = entity.Cost,
                MembershipPeriod = entity.MembershipPeriod
            };

            await _membershipRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _membershipRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MembershipDTO>> GetAllAsync()
        {
            return (await _membershipRepository.GetAllAsync()).Select
                (m => new MembershipDTO()
                {
                    MembershipId = m.MembershipId,
                    Name = m.Name,
                    Cost = m.Cost,
                    MembershipPeriod = m.MembershipPeriod
                });
        }

        public async Task<MembershipDTO> GetByIdAsync(Guid id)
        {
            Membership fromDb = await _membershipRepository.GetByIdAsync(id);

            MembershipDTO membershipDTO = new MembershipDTO()
            {
                MembershipId = fromDb.MembershipId,
                Name = fromDb.Name,
                Cost = fromDb.Cost,
                MembershipPeriod = fromDb.MembershipPeriod
            };
            return membershipDTO;
        }

        public async Task<bool> UpdateAsync(MembershipDTO entity)
        {
            var membership = await _membershipRepository.GetByIdAsync(entity.MembershipId);

            membership.MembershipId = entity.MembershipId;
            membership.Name = entity.Name;
            membership.Cost = entity.Cost;
            membership.MembershipPeriod = entity.MembershipPeriod;
            
            return await _membershipRepository.UpdateAsync(membership);
        }
    }
}
