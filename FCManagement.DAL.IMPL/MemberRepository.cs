using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.DAL.IMPL
{
    public class MemberRepository: GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(FitnessDbContext contextOptions):base(contextOptions){}
    }
}
