using FCManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.BL.ABSTRACT
{
    public interface IWorkoutService
    {
        void AddObject(WorkoutDTO workout);
        void DeleteObject(int id);
        IEnumerable<WorkoutDTO> GetAll();
        WorkoutDTO GetElementById(int id);
        void UpdateObject(WorkoutDTO workout);
    }
}
