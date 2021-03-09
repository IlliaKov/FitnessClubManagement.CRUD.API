using System;
using FCManagement.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FCManagement.DAL.IMPL
{
    public class FitnessDbContext : IdentityDbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options):base(options){}
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
    }
}
