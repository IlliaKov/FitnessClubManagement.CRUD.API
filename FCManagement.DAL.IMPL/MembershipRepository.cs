using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.DAL.IMPL
{
    public class MembershipRepository : GenericRepository<Membership>, IMembershipRepository
    {
        public MembershipRepository(FitnessDbContext contextOptions) : base(contextOptions) { }
    }
}
