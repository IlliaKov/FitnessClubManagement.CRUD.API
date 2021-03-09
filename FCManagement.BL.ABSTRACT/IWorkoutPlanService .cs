using FCManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.BL.ABSTRACT
{
    public interface IWorkoutplanService
    {
        void AddObject(WorkoutPlanDTO workoutPlan);
        void DeleteObject(int id);
        IEnumerable<WorkoutPlanDTO> GetAll();
        WorkoutPlanDTO GetElementById(int id);
        void UpdateObject(WorkoutPlanDTO workoutPlan);
    }
}
