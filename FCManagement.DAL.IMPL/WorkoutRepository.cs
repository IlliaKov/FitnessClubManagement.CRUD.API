using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.DAL.IMPL
{
    public class WorkoutRepository : GenericRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(FitnessDbContext contextOptions) : base(contextOptions) { }
    }
}
