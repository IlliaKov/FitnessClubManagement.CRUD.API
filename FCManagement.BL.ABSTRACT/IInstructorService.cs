using FCManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.BL.ABSTRACT
{
    public interface IInstructorService
    {
        void AddObject(InstructorDTO trainer);
        void DeleteObject(int id);
        IEnumerable<InstructorDTO> GetAll();
        InstructorDTO GetElementById(int id);
        void UpdateObject(InstructorDTO trainer);
    }
}
