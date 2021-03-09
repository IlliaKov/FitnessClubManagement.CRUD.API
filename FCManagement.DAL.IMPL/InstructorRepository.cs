using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.DAL.IMPL
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(FitnessDbContext contextOptions) : base(contextOptions) { }
    }
}
