using FCManagement.DAL.ABSTRACT;
using FCManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.DAL.IMPL
{
    public class WorkoutPlanRepository : GenericRepository<WorkoutPlan>, IWorkoutPlanRepository
    {
        public WorkoutPlanRepository(FitnessDbContext contextOptions) : base(contextOptions) { }
    }
}
