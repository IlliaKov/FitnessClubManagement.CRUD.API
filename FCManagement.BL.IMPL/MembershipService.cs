using FCManagement.BL.ABSTRACT;
using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using FCManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCManagement.BL.IMPL
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipService(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public void AddObject(MembershipDTO membership)
        {
            Membership dbEntity = new Membership()
            {
                Name = membership.Name,
                Cost = membership.Cost,
                MembershipPeriod = membership.MembershipPeriod
            };

            _membershipRepository.Add(dbEntity);
            _membershipRepository.Save();
        }

        public void DeleteObject(int id)
        {
            _membershipRepository.Delete(id);
        }

        public IEnumerable<MembershipDTO> GetAll()
        {
            return _membershipRepository.GetAll().Select(m => new MembershipDTO()
            {
                MembershipId = m.MembershipId,
                Name = m.Name,
                Cost = m.Cost,
                MembershipPeriod = m.MembershipPeriod
            });
        }

        public MembershipDTO GetElementById(int id)
        {
            Membership fromDb = _membershipRepository.GetById(id);

            MembershipDTO membershipDTO = new MembershipDTO()
            {
                MembershipId = fromDb.MembershipId,
                Name = fromDb.Name,
                Cost = fromDb.Cost,
                MembershipPeriod = fromDb.MembershipPeriod
            };
            return membershipDTO;
        }

        public void UpdateObject(MembershipDTO membership)
        {
            Membership memberShipBase = new Membership()
            {
                MembershipId = membership.MembershipId,
                Name = membership.Name,
                Cost = membership.Cost,
                MembershipPeriod = membership.MembershipPeriod
            };
            _membershipRepository.Update(memberShipBase);
        }
    }
}
