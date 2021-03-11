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
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly IWorkoutPlanRepository _workoutPlanRepository;

        public WorkoutPlanService(IWorkoutPlanRepository workoutPlanRepository)
        {
            _workoutPlanRepository = workoutPlanRepository;
        }

        public async Task<int> CountAllAsync()
        {
            return await _workoutPlanRepository.CountAllAsync();
        }

        public async Task CreateAsync(WorkoutPlanDTO entity)
        {
            WorkoutPlan dbEntity = new WorkoutPlan()
            {
                WorkoutDate = entity.WorkoutDate,
                WorkoutTime = entity.WorkoutTime
            };

            await _workoutPlanRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _workoutPlanRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<WorkoutPlanDTO>> GetAllAsync()
        {
            return (await _workoutPlanRepository.GetAllAsync()).Select
                (m => new WorkoutPlanDTO()
                {
                    WorkoutPlanId = m.WorkoutPlanId,
                    WorkoutDate = m.WorkoutDate,
                    WorkoutTime = m.WorkoutTime
                });
        }

        public async Task<WorkoutPlanDTO> GetByIdAsync(Guid id)
        {
            WorkoutPlan fromDb = await _workoutPlanRepository.GetByIdAsync(id);

            WorkoutPlanDTO membershipDTO = new WorkoutPlanDTO()
            {
                WorkoutPlanId = fromDb.WorkoutPlanId,
                WorkoutDate = fromDb.WorkoutDate,
                WorkoutTime = fromDb.WorkoutTime
            };
            return membershipDTO;
        }

        public async Task<bool> UpdateAsync(WorkoutPlanDTO entity)
        {
            WorkoutPlan memberBase = new WorkoutPlan()
            {
                WorkoutPlanId = entity.WorkoutPlanId,
                WorkoutDate = entity.WorkoutDate,
                WorkoutTime = entity.WorkoutTime
            };
            return await _workoutPlanRepository.UpdateAsync(memberBase);
        }
    }
}
