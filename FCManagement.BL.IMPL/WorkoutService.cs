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
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<int> CountAllAsync()
        {
            return await _workoutRepository.CountAllAsync();
        }

        public async Task CreateAsync(WorkoutDTO entity)
        {
            Workout dbEntity = new Workout()
            {
                Name = entity.Name,
                Description = entity.Description
            };

            await _workoutRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _workoutRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<WorkoutDTO>> GetAllAsync()
        {
            return (await _workoutRepository.GetAllAsync()).Select
                (m => new WorkoutDTO()
                {
                    WorkoutId = m.WorkoutId,
                    Name = m.Name,
                    Description = m.Description
                });
        }

        public async Task<WorkoutDTO> GetByIdAsync(Guid id)
        {
            Workout fromDb = await _workoutRepository.GetByIdAsync(id);

            WorkoutDTO membershipDTO = new WorkoutDTO()
            {
                WorkoutId = fromDb.WorkoutId,
                Name = fromDb.Name,
                Description = fromDb.Description
            };
            return membershipDTO;
        }

        public async Task<bool> UpdateAsync(WorkoutDTO entity)
        {
            var workout = await _workoutRepository.GetByIdAsync(entity.WorkoutId);

            workout.WorkoutId = entity.WorkoutId;
            workout.Name = entity.Name;
            workout.Description = entity.Description;
           
            return await _workoutRepository.UpdateAsync(workout);
        }
    }
}
