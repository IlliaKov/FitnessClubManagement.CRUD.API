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
    public class WorkoutPlanService : IWorkoutplanService
    {
        private readonly IWorkoutPlanRepository _workoutPlanRepository;

        public WorkoutPlanService(IWorkoutPlanRepository workoutPlanRepository)
        {
            _workoutPlanRepository = workoutPlanRepository;
        }

        public void AddObject(WorkoutPlanDTO workoutPlan)
        {
            WorkoutPlan dbEntity = new WorkoutPlan()
            {
                WorkoutDate = workoutPlan.WorkoutDate,
                WorkoutTime = workoutPlan.WorkoutTime
            };

            _workoutPlanRepository.Add(dbEntity);
            _workoutPlanRepository.Save();
        }

        public void DeleteObject(int id)
        {
            _workoutPlanRepository.Delete(id);
        }

        public IEnumerable<WorkoutPlanDTO> GetAll()
        {
            return _workoutPlanRepository.GetAll().Select(m => new WorkoutPlanDTO()
            {
                WorkoutPlanId = m.WorkoutPlanId,
                WorkoutDate = m.WorkoutDate,
                WorkoutTime = m.WorkoutTime
            });
        }

        public WorkoutPlanDTO GetElementById(int id)
        {
            WorkoutPlan fromDb = _workoutPlanRepository.GetById(id);

            WorkoutPlanDTO workoutPlanDTO = new WorkoutPlanDTO()
            {
                WorkoutPlanId = fromDb.WorkoutPlanId,
                WorkoutDate = fromDb.WorkoutDate,
                WorkoutTime = fromDb.WorkoutTime
            };
            return workoutPlanDTO;
        }

        public void UpdateObject(WorkoutPlanDTO workoutPlan)
        {
            WorkoutPlan workoutPlanBase = new WorkoutPlan()
            {
                WorkoutPlanId = workoutPlan.WorkoutPlanId,
                WorkoutDate = workoutPlan.WorkoutDate,
                WorkoutTime = workoutPlan.WorkoutTime
            };
            _workoutPlanRepository.Update(workoutPlanBase);
        }
    }
}
