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
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public void AddObject(WorkoutDTO workout)
        {
            Workout dbEntity = new Workout()
            {
                Name = workout.Name,
                Description = workout.Description
            };

            _workoutRepository.Add(dbEntity);
            _workoutRepository.Save();
        }

        public void DeleteObject(int id)
        {
            _workoutRepository.Delete(id);
        }

        public IEnumerable<WorkoutDTO> GetAll()
        {
            return _workoutRepository.GetAll().Select(m => new WorkoutDTO()
            {
                WorkoutId = m.WorkoutId,
                Name = m.Name,
                Description = m.Description
            });
        }

        public WorkoutDTO GetElementById(int id)
        {
            Workout fromDb = _workoutRepository.GetById(id);

            WorkoutDTO membershipDTO = new WorkoutDTO()
            {
                WorkoutId = fromDb.WorkoutId,
                Name = fromDb.Name,
                Description = fromDb.Description
            };
            return membershipDTO;
        }

        public void UpdateObject(WorkoutDTO workout)
        {
            Workout workoutBase = new Workout()
            {
                WorkoutId = workout.WorkoutId,
                Name = workout.Name,
                Description = workout.Description
            };
            _workoutRepository.Update(workoutBase);
        }
    }
}
