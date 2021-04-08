using System.Collections.Generic;
using AutoFixture;
using FCManagement.DAL.IMPL;
using FCManagement.Entities;

namespace FCManagement.IntegrationTests.Util
{
    public class FakeDbInitializer
    {
        public static void Initialize(FitnessDbContext context)
        {
            var fixture = new Fixture();

            var instructors = new List<Instructor>();
            var members = new List<Member>();
            var memberships = new List<Membership>();
            var workouts = new List<Workout>();
            var workoutPlans = new List<WorkoutPlan>();

            for (int i = 0; i < 10; i++)
            {
                instructors.Add(fixture.Create<Instructor>());
                members.Add(fixture.Create<Member>());
                memberships.Add(fixture.Create<Membership>());
                workouts.Add(fixture.Create<Workout>());
                workoutPlans.Add(fixture.Create<WorkoutPlan>());
            }

            context.Instructors.AddRange(instructors);
            context.Members.AddRange(members);
            context.Memberships.AddRange(memberships);
            context.Workouts.AddRange(workouts);
            context.WorkoutPlans.AddRange(workoutPlans);

            context.SaveChanges();
        }
    }
}